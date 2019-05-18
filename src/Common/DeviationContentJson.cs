using System;
using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class DeviationContentJson
    {
        [JsonProperty("src")]
        public Uri SourceUri { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public bool? Transparency { get; set; }
        [JsonProperty("filesize")]
        public long? FileSize { get; set; }
    }
}
