using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    public class BlueprintBook : BlueprintBase
    {
        /// <summary>
        /// The actual content of the blueprint book.
        /// </summary>
        [JsonPropertyName("blueprints")]
        public required List<BlueprintBookChild> Blueprints { get; set; }

        /// <summary>
        /// Index of the currently selected blueprint.
        /// </summary>
        [JsonPropertyName("active_index")]
        public required int ActiveIndex { get; set; }
    }
}