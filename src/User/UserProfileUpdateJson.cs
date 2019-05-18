using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    /// <summary>
    /// Used by:
    ///   POST /user/profile/update
    /// </summary>
    public class UserProfileUpdateJson
    {
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        public bool Success { get; set; }
    }
}
