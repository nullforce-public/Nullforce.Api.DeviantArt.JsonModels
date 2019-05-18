using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class TagNameJson
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }
    }
}
