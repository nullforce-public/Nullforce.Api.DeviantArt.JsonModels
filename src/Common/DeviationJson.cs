using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class DeviationJson
    {
        public string DeviationId { get; set; }
        public string PrintId { get; set; }
        [JsonProperty("url")]
        public Uri Uri { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        [JsonProperty("category_path")]
        public string CategoryPath { get; set; }
        [JsonProperty("is_favourited")]
        public bool? IsFavorited { get; set; }
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }
        public AuthorJson Author { get; set; }
        public DeviationStatsJson Stats { get; set; }
        [JsonProperty("published_time")]
        [JsonConverter(typeof(JavaScriptDateTimeConverter))] // JavaScriptDateTimeConverter, IsoDateTimeConverter
        public DateTime? PublishedTime { get; set; }
        public bool? AllowsComments { get; set; }
        public DeviationContentJson Preview { get; set; }
        public DeviationContentJson Content { get; set; }
        [JsonProperty("thumbs")]
        public DeviationContentJson[] Thumbnails { get; set; }
        public DeviationContentJson Videos { get; set; }
        public DeviationContentJson Flash { get; set; }
        [JsonProperty("daily_deviation")]
        public DailyDeviationJson DailyDeviation { get; set; }
        public bool? IsMature { get; set; }
        public bool? IsDownloadable { get; set; }
        [JsonProperty("download_filesize")]
        public long? DownloadFilesize { get; set; }
        public string Excerpt { get; set; }
    }
}
