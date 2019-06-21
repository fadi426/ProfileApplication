using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProfileApplication.Models.Places
{
    public class Places
    {
        [JsonProperty("Title")]
        public string name { get; set; }
    }
}