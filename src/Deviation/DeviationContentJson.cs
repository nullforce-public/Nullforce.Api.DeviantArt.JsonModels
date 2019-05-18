using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class DeviationContentJson
    {
        public string Html { get; set; }
        public string Css { get; set; }
        [JsonProperty("css_fonts")]
        public string[] CssFonts { get; set; }
    }
}
