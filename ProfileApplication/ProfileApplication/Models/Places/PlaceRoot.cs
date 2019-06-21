using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProfileApplication.Models.Places
{
    public class PlaceRoot
    {
        [JsonProperty("odata.metadata")]
        public string RootUrl { get; set; }
        
        [JsonProperty("value")]
        public Places[] Places { get; set; }
    }
}