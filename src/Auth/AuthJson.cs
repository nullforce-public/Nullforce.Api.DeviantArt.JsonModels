using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class AuthJson
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
        public string Status { get; set; }
    }
}
