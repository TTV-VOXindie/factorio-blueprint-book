using System.Text.Json.Serialization;

namespace BlueprintStringDataModels
{
    /// <summary>
    /// Parameters supplied to a contant combinator.
    /// </summary>
    public class ConstantCombinatorParameters
    {
        /// <summary>
        /// Signal to emit.
        /// </summary>
        [JsonPropertyName("signal")]
        public required SignalId Signal { get; set; }

        /// <summary>
        /// Value of the signal to emit.
        /// </summary>
        [JsonPropertyName("count")]
        public required int Count { get; set; }

        /// <summary>
        /// Index of the constant combinator's slot to set this signal to.
        /// </summary>
        [JsonPropertyName("index")]
        public required int Index { get; set; }
    }
}