using CommandLine;

namespace FactorioImageAssetImporter
{
    public class ActionInputs
    {
        [Option(
            shortName: 'a',
            longName: "assetDir",
            Required = true,
            HelpText = "The root directory of where to import the image assets from."
            )]
        public string AssetDirectory { get; set; } = null!;

        [Option(
            shortName: 'f',
            longName: "foldersToCopy",
            Required = true,
            HelpText = "A list of the folders in the root directory to copy."
            )]
        public IEnumerable<string> FoldersToCopy { get; set; } = null!;

        [Option(
            shortName: 'o',
            longName: "outputDir",
            Required = true,
            HelpText = "The root directory of where to export the image assets to."
            )]
        public string OutputDirectory { get; set; } = null!;


    }
}