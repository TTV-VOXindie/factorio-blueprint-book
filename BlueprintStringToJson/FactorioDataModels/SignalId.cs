using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    public class SignalId
    {
        /// <summary>
        /// "item" or "fluid" or "virtual"
        /// </summary>
        [JsonPropertyName("type")]
        public required string Type { get; set; }

        /// <summary>
        /// Name of the item, fluid or virtual signal.
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}