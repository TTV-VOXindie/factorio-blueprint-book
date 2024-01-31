using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    public class ControlBehavior
    {
        /// <summary>
        /// Array of <see cref="ConstantCombinatorParameters"/>.
        /// </summary>
        [JsonPropertyName("filters")]
        public List<ConstantCombinatorParameters>? Filters { get; set; }
    }
}