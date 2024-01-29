using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

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

        /// <summary>
        /// Blueprint string format information taken from here: https://wiki.factorio.com/Blueprint_string_format
        /// </summary>
        /// <param name="blueprintString"></param>
        /// <returns></returns>
        private static async Task<string> _blueprintStringToJson(string blueprintString)
        {
            //skip the first byte and decode from base 64
            byte[] decodedBlueprintString = Convert.FromBase64String(blueprintString.Substring(1));

            using (MemoryStream inputStream = new MemoryStream(decodedBlueprintString))
            using (ZLibStream zInputStream = new ZLibStream(inputStream, CompressionMode.Decompress))
            using (MemoryStream outputStream = new MemoryStream())
            {

                await zInputStream.CopyToAsync(outputStream);
                byte[] decompressed = outputStream.ToArray();

                string blueprintJsonUnformatted = Encoding.Default.GetString(decompressed);

                return JsonNode.Parse(blueprintJsonUnformatted)!.ToJsonString(new JsonSerializerOptions() { WriteIndented = true });
            }
        }

        private static async Task<string> _incrementBlueprintVersionNumber(ActionInputs inputs, IHost host, CancellationTokenSource tokenSource)
        {
            ILogger log = _get<ILoggerFactory>(host)
                    .CreateLogger(nameof(_incrementBlueprintVersionNumber));

            int newVersion = 0;

            //get the file path for the version file
            string versionFileName = "version.txt";
            string versionFullPath = Path.Combine(inputs.Directory, versionFileName);

            //if there's a version file
            if(File.Exists(versionFullPath))
            {
                //read the version file
                string previousVersionString = await File.ReadAllTextAsync(versionFullPath);

                //parse version as int
                int previousVersion = int.Parse(previousVersionString);

                //increment the version
                newVersion = previousVersion + 1;

                log.LogInformation($"Version file found with version {previousVersion}");
            }

            log.LogInformation($"Updating version to {newVersion}.");

            string newVersionString = newVersion.ToString();

            //save version
            await File.WriteAllTextAsync(
                path: versionFullPath,
                contents: newVersionString,
                cancellationToken: tokenSource.Token
                );

            return newVersionString;
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

        private static async Task _updateBlueprintReadme(string version, ActionInputs inputs, CancellationTokenSource tokenSource)
        {
            //get the template for the README
            string readmeTemplate = _readResource("Blueprint Files README Template.md");

            //replace the tokens in the template
            string readmeContents = readmeTemplate
                .Replace("{{version}}", version.ToString());

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

            //convert blueprint string to JSON
            string blueprintJson = await _blueprintStringToJson(blueprintString);

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
                wasBlueprintChanged = blueprintJson != blueprintJsonPrevious;
            }
            else //the blueprint was changed if we don't have a previous version
            {
                wasBlueprintChanged = true;
            }

            //if the blueprint was changed
            if (wasBlueprintChanged)
            {
                //log what we're doing with the file
               log.LogInformation($"{(doesPreviousBlueprintFileExist ? "Updating" : "Creating")} {outputFileName} with latest data.");

                //write to the file
                await File.WriteAllTextAsync(
                        path: outputFullPath,
                        contents: blueprintJson,
                        cancellationToken: tokenSource.Token
                        );

                //increment the version number
                string version = await _incrementBlueprintVersionNumber(inputs, host, tokenSource);

                //update the readme
                await _updateBlueprintReadme(version, inputs, tokenSource);
            }
            else
            {
                log.LogInformation($"{outputFileName} was not changed.");
            }


            // https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter
            string? githubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT", EnvironmentVariableTarget.Process);
            if (!string.IsNullOrWhiteSpace(githubOutputFile))
            {
                using (StreamWriter textWriter = new StreamWriter(githubOutputFile!, true, Encoding.UTF8))
                {
                    textWriter.WriteLine($"was-blueprint-changed={wasBlueprintChanged.ToString().ToLower()}"); //this is done so we don't get weird shit happening in the github action workflow
                    //textWriter.WriteLine("summary-details<<EOF");
                    //textWriter.WriteLine(summary);
                    //textWriter.WriteLine("EOF");
                }
            }
            else
            {
                Console.WriteLine($"::set-output name=was-blueprint-changed::{wasBlueprintChanged.ToString().ToLower()}");
            }

            Environment.Exit(0);
        }
    }
}

