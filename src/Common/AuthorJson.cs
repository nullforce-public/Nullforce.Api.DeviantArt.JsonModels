using System;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class AuthorJson
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public Uri UserIcon { get; set; }
        public string Type { get; set; }
    }
}
