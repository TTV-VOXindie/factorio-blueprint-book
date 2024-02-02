using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    public class Entity
    {
        /// <summary>
        /// Index of the entity, 1-based.
        /// </summary>
        [JsonPropertyName("entity_number")]
        public required int EntityNumber { get; set; }

        /// <summary>
        /// Prototype name of the entity.
        /// </summary>
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        /// <summary>
        /// Position of the entity within the blueprint.
        /// </summary>
        [JsonPropertyName("position")]
        public required Position Position { get; set; }

        /// <summary>
        /// Direction of the entity.
        /// </summary>
        [JsonPropertyName("direction")]
        public Direction? Direction { get; set; } //TODO: this should only write when it's >= 0

        /// <summary>
        /// Orientation of cargo wagon or locomotive.
        /// </summary>
        [JsonPropertyName("orientation")]
        public float? Orientation { get; set; }

        /// <summary>
        /// Copper wire connections.
        /// </summary>
        [JsonPropertyName("neighbours")]
        public List<int>? Neighbours { get; set; }

        /// <summary>
        /// Control behavior object of this entity.
        /// </summary>
        [JsonPropertyName("control_behavior")]
        public ControlBehavior? ControlBehavior { get; set; }
    }
}