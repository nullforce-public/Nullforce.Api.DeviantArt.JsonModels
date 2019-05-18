using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    /// <summary>
    /// Used by:
    ///   POST /user/friends/watch/{username}
    /// </summary>
    public class UserFriendsWatchJson
    {
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        public bool Success { get; set; }
    }
}
