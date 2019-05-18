using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class PagedResponse<T> where T : class
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("next_offset")]
        public long? NextOffset { get; set; }
        [JsonProperty("estimated_total")]
        public long? EstimatedTotal { get; set; }
        // Used in: GET /gallery/folder/{folderid}
        public string Name { get; set; }

        public T[] Results { get; set; }
    }
}
