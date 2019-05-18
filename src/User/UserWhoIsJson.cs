namespace Nullforce.Api.DeviantArt.JsonModels
{
    /// <summary>
    /// Used by:
    ///   POST /user/whois
    /// </summary>
    public class UserWhoIsJson
    {
        public UserJson[] Results { get; set; }
    }
}
