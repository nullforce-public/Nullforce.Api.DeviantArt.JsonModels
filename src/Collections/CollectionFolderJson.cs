using Newtonsoft.Json;

namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class CollectionFolderJson
    {
        public string FolderId { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
        public DeviationJson[] Deviations { get; set; }
    }
}
