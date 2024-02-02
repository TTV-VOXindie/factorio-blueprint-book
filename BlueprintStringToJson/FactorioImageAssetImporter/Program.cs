using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace FactorioImageAssetImporter
{
    internal class Program
    {
        static async Task Main(string[] args)
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
                    host.Services.GetRequiredService<ILoggerFactory>()
                        .CreateLogger("FactorioImageAssetImporter.Program")
                        .LogError(
                            string.Join(
                                separator: Environment.NewLine,
                                values: errors.Select(e => e.ToString())
                                )
                            );

                    Environment.Exit(2);
                });

            await parser.WithParsedAsync(inputs => _run(inputs, host));
        }

        private static void _copyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            //get information about the source directory
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            //check if the source directory exists
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            }

            //cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            //create the destination directory
            Directory.CreateDirectory(destinationDir);

            //get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            //if recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    _copyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        private static async Task _run(ActionInputs inputs, IHost host)
        {
            ILoggerFactory loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            ILogger logger = loggerFactory.CreateLogger(nameof(_run));

            //log info
            logger.LogInformation($"Copying from {inputs.AssetDirectory} to {inputs.OutputDirectory}.");

            foreach (string folder in inputs.FoldersToCopy)
            {
                logger.LogInformation($"Copying {folder}.");

                string sourceDirectory = Path.Combine(inputs.AssetDirectory, folder);
                string destinationDirectory = Path.Combine(inputs.OutputDirectory, folder);

                //copy the directory
                _copyDirectory(sourceDirectory, destinationDirectory, true);
            }
        }
    }
}