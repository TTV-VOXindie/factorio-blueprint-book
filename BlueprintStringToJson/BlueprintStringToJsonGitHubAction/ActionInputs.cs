using CommandLine;

namespace BlueprintStringToJsonGitHubAction
{
    public class ActionInputs
    {
        [Option(
            shortName: 'd',
            longName: "dir",
            Required = true,
            HelpText = "The root directory to start recursive searching from."
            )]
        public string Directory { get; set; } = null!;
    }
}