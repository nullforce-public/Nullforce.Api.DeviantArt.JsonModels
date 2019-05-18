using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class DeviationWhoFavedJson
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        [JsonProperty("next_offset")]
        public long? NextOffset { get; set; }
        public UserFaveJson[] Results { get; set; }

        public class UserFaveJson
        {
            public UserJson User { get; set; }
            public long Time { get; set; }
        }
    }
}
