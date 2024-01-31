using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    /// <summary>
    /// Data representation of the JSON in a blueprint string.
    /// </summary>
    public class BlueprintStringJsonModel
    {
        [JsonPropertyName("blueprint_book")]
        public BlueprintBook? BlueprintBook { get; set; }

        [JsonPropertyName("blueprint")]
        public Blueprint? Blueprint { get; set; }
    }
}