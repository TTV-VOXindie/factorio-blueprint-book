using System.IO.Compression;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace BlueprintStringToJsonGitHubAction
{
    internal class BlueprintStringDecoder
    {
        /// <summary>
        /// Decodes a blueprint string into JSON.  More information on blueprint string format here: https://wiki.factorio.com/Blueprint_string_format
        /// </summary>
        /// <param name="blueprintString"></param>
        /// <returns>The blueprint as JSON.</returns>
        public async Task<string> DecodeToJsonAsync(string blueprintString)
        {
            //skip the first byte and decode from base 64
            byte[] decodedBlueprintString = Convert.FromBase64String(blueprintString.Substring(1));

            using (MemoryStream inputStream = new MemoryStream(decodedBlueprintString))
            using (ZLibStream zInputStream = new ZLibStream(inputStream, CompressionMode.Decompress))
            using (MemoryStream outputStream = new MemoryStream())
            {

                await zInputStream.CopyToAsync(outputStream);
                byte[] decompressed = outputStream.ToArray();

                string blueprintJsonUnformatted = Encoding.Default.GetString(decompressed);

                return JsonNode.Parse(blueprintJsonUnformatted)!.ToJsonString(new JsonSerializerOptions() { WriteIndented = true });
            }
        }
    }
}
