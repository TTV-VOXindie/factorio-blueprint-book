using BlueprintStringDataAccess;
using BlueprintStringDataModels;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO.Compression;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BlueprintStringToJsonGitHubAction
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string? greetings = Environment.GetEnvironmentVariable("GREETINGS");
            if (greetings?.Length > 0)
            {
                Console.WriteLine(greetings);
            }

            //build host
            using IHost host = Host.CreateDefaultBuilder(args).Build();

            //build command line parser
            ParserResult<ActionInputs> parser = Parser.Default.ParseArguments(
                factory: () => new ActionInputs(),
                args: args
                );

            //config parser to log errors
            parser.WithNotParsed(
                errors =>
                {
                    _get<ILoggerFactory>(host)
                        .CreateLogger("BlueprintStringToJsonGitHubAction.Program")
                        .LogError(
                            string.Join(
                                separator: Environment.NewLine,
                                values: errors.Select(e => e.ToString())
                                )
                            );

                    Environment.Exit(2);
                });

            await parser.WithParsedAsync(options => _run(options, host));
            await host.RunAsync();
        }

        private static TService _get<TService>(IHost host) where TService : notnull
        {
            return host.Services.GetRequiredService<TService>();
        }

        private static async Task<int> _getBlueprintVersion(ActionInputs inputs, IHost host, CancellationTokenSource tokenSource)
        {
            ILogger log = _get<ILoggerFactory>(host)
                    .CreateLogger(nameof(_getBlueprintVersion));

            //get the file path for the version file
            string versionFileName = "version.txt";
            string versionFullPath = Path.Combine(inputs.Directory, versionFileName);

            //if there's a version file
            if (File.Exists(versionFullPath))
            {
                //read the version file
                string versionString = await File.ReadAllTextAsync(versionFullPath);

                //parse version as int
                int version = int.Parse(versionString);

                return version;
            }

            return 0;
        }

        private static async Task<int> _incrementBlueprintVersionNumber(ActionInputs inputs, IHost host, int version, CancellationTokenSource tokenSource)
        {
            ILogger log = _get<ILoggerFactory>(host)
                    .CreateLogger(nameof(_incrementBlueprintVersionNumber));

            int newVersion = version + 1;

            //get the file path for the version file
            string versionFileName = "version.txt";
            string versionFullPath = Path.Combine(inputs.Directory, versionFileName);

            string newVersionString = newVersion.ToString();


            log.LogInformation($"Updating version to {newVersionString}");
            //save version
            await File.WriteAllTextAsync(
                path: versionFullPath,
                contents: newVersionString,
                cancellationToken: tokenSource.Token
                );

            return newVersion;
        }

        private static string _readResource(string name)
        {
            //get assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            //format: "{Namespace}.{Folder}.{filename}.{Extension}"
            string resourcePath = assembly.GetManifestResourceNames()
                    .Single(str => str.EndsWith(name));

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath)!)
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static async Task _updateMainReadme(string blueprintString, string version, CancellationTokenSource tokenSource)
        {
            //get the template for the README
            string readmeTemplate = _readResource("Main README Template.md");

            //replace the tokens in the template
            string readmeContents = readmeTemplate
                .Replace("{{blueprint-string}}", blueprintString)
                .Replace("{{version}}", version.ToString());

            //get the file path for the readme
            string fileName = "README.md";
            string fullPath = fileName;

            //write the readme
            await File.WriteAllTextAsync(
                path: fullPath,
                contents: readmeContents,
                cancellationToken: tokenSource.Token
                );
        }

        private static async Task _updateBlueprintReadme(string blueprintString, string version, ActionInputs inputs, CancellationTokenSource tokenSource)
        {
            //get the template for the README
            string readmeTemplate = _readResource("Blueprint Files README Template.md");

            //replace the tokens in the template
            string readmeContents = readmeTemplate
                .Replace("{{blueprint-string}}", blueprintString)
                .Replace("{{version}}", version);

            //get the file path for the readme
            string fileName = "README.md";
            string fullPath = Path.Combine(inputs.Directory, fileName);

            //write the readme
            await File.WriteAllTextAsync(
                path: fullPath,
                contents: readmeContents,
                cancellationToken: tokenSource.Token
                );
        }

        private static async Task _writeBlueprintStringJson(ILogger logger, ActionInputs inputs, string blueprintJson, CancellationToken cancellationToken)
        {
            BlueprintStringJsonModel? blueprintStringJson = JsonSerializer.Deserialize<BlueprintStringJsonModel>(blueprintJson);
            
            if (blueprintStringJson == null)
            {
                logger.LogWarning("Blueprint JSON is null.");
                return;
            }

            BlueprintStringJsonModelValidator validator = new BlueprintStringJsonModelValidator();

            if(!validator.IsValid(blueprintStringJson))
            {
                logger.LogError("Blueprint JSON is not valid.");
                return;
            }


            if (blueprintStringJson.BlueprintBook == null)
            {
                logger.LogError("Root blueprint JSON is not a blueprint book.");
                return;
            }

            string baseJsonDirectory = Path.Combine(inputs.Directory, "JSON");
            
            if (Directory.Exists(baseJsonDirectory))
            {
                //delete the JSON folder
                Directory.Delete(baseJsonDirectory, true);
            }

            Directory.CreateDirectory(baseJsonDirectory);

            await _handleBlueprintBookJson(logger, baseJsonDirectory, null, blueprintStringJson.BlueprintBook!, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="index">The index of the blueprint book (if it is a child).</param>
        /// <param name="blueprintBook"></param>
        /// <returns></returns>
        private static async Task _handleBlueprintBookJson(ILogger logger, string parent, int? index, BlueprintBook blueprintBook, CancellationToken cancellationToken)
        {
            //strip out invalid path name chars
            string fileName = _sanitizeLabel(blueprintBook.Label);

            string folderName = fileName;

            if(index != null)
            {
                folderName = $"[{index}] {fileName}";
            }

            string folderPath = Path.Combine(parent, folderName);
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{fileName}.json");
            string blueprintBookJson = JsonSerializer.Serialize(blueprintBook, new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

            //write the json
            await File.WriteAllTextAsync(
              path: filePath,
              contents: blueprintBookJson,
              cancellationToken: cancellationToken
              );

            for (int i = 0; i < blueprintBook.Blueprints.Count; i++)
            {
                BlueprintBookChild child = blueprintBook.Blueprints[i];

                if (child.Blueprint != null)
                {
                    await _handleBlueprintJson(logger, folderPath, child.Index, child.Blueprint, cancellationToken);
                }
                else if(child.BlueprintBook != null)
                {
                    await _handleBlueprintBookJson(logger, folderPath, child.Index, child.BlueprintBook, cancellationToken);
                }
                else
                {
                    logger.LogWarning($"'{folderName}' Child [{i}] did not have data.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="index">The index of the blueprint (if it is a child).</param>
        /// <param name="blueprint"></param>
        /// <returns></returns>
        private static async Task _handleBlueprintJson(ILogger logger, string parent, int? index, Blueprint blueprint, CancellationToken cancellationToken)
        {
            //strip out invalid path name chars
            string fileName = _sanitizeLabel(blueprint.Label);

            string folderName = fileName;

            if (index != null)
            {
                folderName = $"[{index}] {fileName}";
            }

            string folderPath = Path.Combine(parent, folderName);
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, $"{fileName}.json");
            string blueprintJson = JsonSerializer.Serialize(blueprint, new JsonSerializerOptions() { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

            //write the json
            await File.WriteAllTextAsync(
              path: filePath,
              contents: blueprintJson,
              cancellationToken: cancellationToken
              );
        }

        private static string _sanitizeLabel(string label)
        {
            return _replaceInvalidPathNameChars(label.ToCharArray()).Trim();
        }

        private static HashSet<char> _invalidFileNameChars = new HashSet<char>()
        {
            '/',
            '\\',
            '?',
            '%',
            '*',
            ':',
            '|',
            '"',
            '<',
            '>',
            '.',
            ',',
            ';',
            '='
        };

        private static string _replaceInvalidPathNameChars(char[] blueprintLabel)
        {
            for (int i = 0; i < blueprintLabel.Length; i++)
            {
                char c = blueprintLabel[i];
                if (_invalidFileNameChars.Contains(c) || char.IsControl(c))
                {
                    blueprintLabel[i] = '_';
                }
            }

            return new string(blueprintLabel);
        }

        private static async Task _run(ActionInputs inputs, IHost host)
        {
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            ILogger log = _get<ILoggerFactory>(host).CreateLogger(nameof(_run));

            string fileName = "BlueprintBook.txt"; //TODO: make this part of the input
            string fullPath = Path.Combine(inputs.Directory, fileName);
            bool fileExists = File.Exists(fullPath);

            if(!fileExists)
            {
                _get<ILoggerFactory>(host)
                    .CreateLogger(nameof(_run))
                    .LogInformation($"{fileName} does not exist!");

                return;
            }

            //read the blueprint string from the file
            string blueprintString = await File.ReadAllTextAsync(fullPath, tokenSource.Token);

            BlueprintStringDecoder blueprintDecoder = new BlueprintStringDecoder();

            //convert blueprint string to JSON
            string blueprintJson = await blueprintDecoder.DecodeToJsonAsync(blueprintString);          

            //get the file path for the blueprint json file
            string outputFileName = "BlueprintBook.json"; //TODO: make this part of the input
            string outputFullPath = Path.Combine(inputs.Directory, outputFileName);
            bool doesPreviousBlueprintFileExist = File.Exists(outputFullPath);

            bool wasBlueprintChanged;

            //if a blueprint json file already exists
            if (doesPreviousBlueprintFileExist)
            {
                //read the previous blueprint json
                string blueprintJsonPrevious = await File.ReadAllTextAsync(outputFullPath, tokenSource.Token);

                //blueprint was changed if it differs from the previous version
                wasBlueprintChanged = blueprintJson.ReplaceLineEndings(Environment.NewLine) != blueprintJsonPrevious.ReplaceLineEndings(Environment.NewLine);
            }
            else //the blueprint was changed if we don't have a previous version
            {
                wasBlueprintChanged = true;
            }

            //log what we're doing with the file
            log.LogInformation($"{(doesPreviousBlueprintFileExist ? "Updating" : "Creating")} {outputFileName} with latest data.");

            await _writeBlueprintStringJson(
                logger: _get<ILoggerFactory>(host).CreateLogger(nameof(_writeBlueprintStringJson)),
                inputs: inputs,
                blueprintJson: blueprintJson,
                cancellationToken: tokenSource.Token
                );

            //write to the file
            await File.WriteAllTextAsync(
                    path: outputFullPath,
                    contents: blueprintJson,
                    cancellationToken: tokenSource.Token
                    );

            int version = await _getBlueprintVersion(inputs, host, tokenSource);

            //if the blueprint was changed
            if (wasBlueprintChanged)
            {
                //increment the version number
                version = await _incrementBlueprintVersionNumber(inputs, host, version, tokenSource);
            }
            else
            {
                log.LogInformation($"{outputFileName} was not changed.");
            }

            //update the main readme
            await _updateMainReadme(blueprintString, version.ToString(), tokenSource);

            //update the readme
            await _updateBlueprintReadme(blueprintString, version.ToString(), inputs, tokenSource);

            // https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter
            string? githubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT", EnvironmentVariableTarget.Process);
            if (!string.IsNullOrWhiteSpace(githubOutputFile))
            {
                using (StreamWriter textWriter = new StreamWriter(githubOutputFile!, true, Encoding.UTF8))
                {
                    textWriter.WriteLine($"was-blueprint-changed={wasBlueprintChanged.ToString().ToLower()}"); //the ToLower is done so we don't get weird shit happening in the github action workflow
                    textWriter.WriteLine($"blueprint-version={version}");
                    //textWriter.WriteLine("summary-details<<EOF");
                    //textWriter.WriteLine(summary);
                    //textWriter.WriteLine("EOF");
                }
            }
            else
            {
                Console.WriteLine($"::set-output name=was-blueprint-changed::{wasBlueprintChanged.ToString().ToLower()}");
                Console.WriteLine($"::set-output name=blueprint-version::{version}");
            }

            Environment.Exit(0);
        }
    }
}

