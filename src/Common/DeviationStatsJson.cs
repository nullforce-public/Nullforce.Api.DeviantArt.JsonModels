using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class DeviationStatsJson
    {
        public long Comments { get; set; }
        [JsonProperty("favourites")]
        public long Favorites { get; set; }
    }
}
