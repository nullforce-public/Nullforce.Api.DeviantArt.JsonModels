using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class DailyDeviationJson
    {
        public string Body { get; set; }
        public string Time { get; set; }
        public AuthorJson Giver { get; set; }
        public AuthorJson Suggester { get; set; }
    }
}
