using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class GalleryFolderJson
    {
        public string FolderId { get; set; }
        [JsonProperty("Parent")]
        public string ParentFolderId { get; set; }
        public string Name { get; set; }
    }
}
