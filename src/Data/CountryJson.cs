namespace Nullforce.Api.DeviantArt.JsonModels
{
    public class CountriesRootJson
    {
        public CountryJson[] Results { get; set; }
    }

    public class CountryJson
    {
        public long CountryId { get; set; }
        public string Name { get; set; }
    }
}
