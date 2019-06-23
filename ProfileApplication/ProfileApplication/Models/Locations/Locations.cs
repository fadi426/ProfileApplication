using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProfileApplication.Models.Places
{
    public class Locations
    {
        [JsonProperty("Title")]
        public string name { get; set; }
    }
}