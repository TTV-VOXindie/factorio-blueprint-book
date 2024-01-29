using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BlueprintStringToJsonGitHubAction
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
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

        private static async Task _run(ActionInputs inputs, IHost host)
        {
            using CancellationTokenSource tokenSource = new CancellationTokenSource();

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

            string blueprintJson = await _blueprintStringToJson(blueprintString);

            string outputFileName = "BlueprintBook.json";
            string outputFullPath = Path.Combine(inputs.Directory, outputFileName);
            bool outputFileExists = File.Exists(outputFullPath);

            _get<ILoggerFactory>(host)
                    .CreateLogger(nameof(_run))
                    .LogInformation($"{(outputFileExists ? "Updating" : "Creating")} {outputFileName} with latest data.");

            string? blueprintJsonPrevious = null;
            if (outputFileExists)
            {
                blueprintJsonPrevious = await File.ReadAllTextAsync(outputFullPath, tokenSource.Token);
            }

            bool wasBlueprintChanged = !outputFileExists || blueprintJson != blueprintJsonPrevious;

            await File.WriteAllTextAsync(
                    path: outputFullPath,
                    contents: blueprintJson,
                    cancellationToken: tokenSource.Token
                    );


            // https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter
            string? githubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT", EnvironmentVariableTarget.Process);
            if (!string.IsNullOrWhiteSpace(githubOutputFile))
            {
                using (StreamWriter textWriter = new StreamWriter(githubOutputFile!, true, Encoding.UTF8))
                {
                    textWriter.WriteLine($"was-blueprint-changed={wasBlueprintChanged}");
                    //textWriter.WriteLine("summary-details<<EOF");
                    //textWriter.WriteLine(summary);
                    //textWriter.WriteLine("EOF");
                }
            }
            else
            {
                Console.WriteLine($"::set-output name=was-blueprint-changed::{wasBlueprintChanged}");
            }

            Environment.Exit(0);
        }

    }
}

