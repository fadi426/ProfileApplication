using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProfileApplication.Models
{
    public class LiveWeather
    {
        [JsonProperty("liveweer")]
        public List<WeatherInfo> WeatherArr { get; set; }
    }
}