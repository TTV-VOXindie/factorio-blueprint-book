using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    /// <summary>
    /// A child entry in a <see cref="BlueprintBook"/>.
    /// Can contain either a <see cref="BlueprintBook"/> or a <see cref="Blueprint"/>.
    /// </summary>
    public class BlueprintBookChild //TODO: need to have a custom accessor?
    {
        [JsonPropertyName("blueprint_book")]
        public BlueprintBook? BlueprintBook { get; set; }

        [JsonPropertyName("index")]
        public int? Index { get; set; }

        [JsonPropertyName("blueprint")]
        public Blueprint? Blueprint { get; set; }
    }
}