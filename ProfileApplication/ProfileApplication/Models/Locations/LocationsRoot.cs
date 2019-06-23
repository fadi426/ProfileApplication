using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProfileApplication.Models.Places
{
    public class LocationsRoot
    {
        [JsonProperty("odata.metadata")]
        public string RootUrl { get; set; }
        
        [JsonProperty("value")]
        public Locations[] Locations { get; set; }
    }
}