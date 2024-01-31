using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    /// <summary>
    /// Base class for <see cref="Blueprint"/> and <see cref="BlueprintBook"/>
    /// </summary>
    public class BlueprintBase
    {
        /// <summary>
        /// The name of the item that was saved (should be "blueprint" or "blueprint-book").
        /// </summary>
        [JsonPropertyName("item")]
        public required string Item { get; set; }

        /// <summary>
        /// The name of the blueprint set by the user.
        /// </summary>
        [JsonPropertyName("label")]
        public required string Label { get; set; }

        /// <summary>
        /// The description of the blueprint. Optional.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// The icons of the blueprint set by the user.
        /// </summary>
        [JsonPropertyName("icons")]
        public required List<Icon> Icons { get; set; }

        /// <summary>
        /// The map version of the map the blueprint was created in.
        /// </summary>
        [JsonPropertyName("version")]
        public required long Version { get; set; }
    }
}