using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProfileApplication.Models
{
    public class WeatherRoot
    {
        [JsonProperty("liveweer")]
        public List<Weather> WeatherArr { get; set; }
    }
}