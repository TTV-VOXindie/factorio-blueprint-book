using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    public class Position
    {
        /// <summary>
        /// X position within the blueprint, 0 is the center.
        /// </summary>
        [JsonPropertyName("x")]
        public float X { get; set; }

        /// <summary>
        /// Y position within the blueprint, 0 is the center.
        /// </summary>
        [JsonPropertyName("y")]
        public float Y { get; set; }
    }
}