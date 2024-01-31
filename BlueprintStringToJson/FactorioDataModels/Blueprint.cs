using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    public class Blueprint : BlueprintBase
    {
        /// <summary>
        /// The dimensions of the grid to use for snapping. Optional.
        /// </summary>
        [JsonPropertyName("snap-to-grid")]
        public Position? SnapToGrid { get; set; }

        /// <summary>
        /// The actual content of the blueprint.
        /// </summary>
        [JsonPropertyName("entities")]
        public required List<Entity> Entities { get; set; }
    }
}