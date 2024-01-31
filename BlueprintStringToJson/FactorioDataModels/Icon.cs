using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    /// <summary>
    /// Icon for a signal. 
    /// </summary>
    public class Icon
    {
        /// <summary>
        /// Index of the icon, 1-based.
        /// </summary>
        [JsonPropertyName("index")]
        public required int Index { get; set; }

        /// <summary>
        /// The icon that is displayed.
        /// </summary>
        [JsonPropertyName("signal")]
        public required SignalId Signal { get; set; }
    }
}