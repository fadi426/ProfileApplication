using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProfileApplication.Models
{
    public class WeatherInfo
    {
        [JsonProperty("plaats")]
        public string Location { get; set; }
        
        [JsonProperty("temp")]
        public string Temperature { get; set; }
        
        [JsonProperty("gtemp")] 
        public string AverageTemperature { get; set; }
        
        [JsonProperty("samenv")]
        public string Summary { get; set; }
        
        [JsonProperty("lv")]
        public string Humidity { get; set; }
        
        [JsonProperty("windr")]
        public string WindDirection { get; set; }
        
        [JsonProperty("windms")]
        public string WindSpeedMs { get; set; }
        
        [JsonProperty("winds")]
        public string WindForce { get; set; }
        
        [JsonProperty("windk")]
        public string WindSpeedK { get; set; }
        
        [JsonProperty("windkmh")]
        public string WindSpeedKmH { get; set; }
        
        [JsonProperty("luchtd")]
        public string AirPressure { get; set; }
        
        [JsonProperty("idmmhg")]
        public string AirPressureMmk { get; set; }
        
        [JsonProperty("dauwp")]
        public string DewPoint { get; set; }
        
        [JsonProperty("zicht")]
        public string VisibilityKm { get; set; }
        
        [JsonProperty("verw")]
        public string DayForecast { get; set; }
        
        [JsonProperty("sup")]
        public string SunUp { get; set; }
        
        [JsonProperty("sunder")]
        public string SunUnder { get; set; }
        
        [JsonProperty("image")]
        public string ImageName { get; set; }
        
        [JsonProperty("d0weer")]
        public string WeatherIconDay0 { get; set; }
        
        [JsonProperty("d0tmax")]
        public string MaxTempDay0 { get; set; }
        
        [JsonProperty("d0tmin")]
        public string MinTempDay0 { get; set; }

        [JsonProperty("d0windk")]
        public string WindForceDay0{ get; set; }
        
        [JsonProperty("d0windr")]
        public string WindDirectionDay0{ get; set; }
        
        [JsonProperty("d0neerslag")]
        public string PrecipitationProbDay0{ get; set; }
        
        [JsonProperty("d0zon")]
        public string SunChanceDay0{ get; set; }
        
        [JsonProperty("d1weer")]
        public string WeatherIconDay1 { get; set; }
        
        [JsonProperty("d1tmax")]
        public string MaxTempDay1{ get; set; }
        
        [JsonProperty("d1tmin")]
        public string MinTempDay1{ get; set; }
        
        [JsonProperty("d1windk")]
        public string WindForceDay1{ get; set; }
        
        [JsonProperty("d1windr")]
        public string WindDirectionDay1{ get; set; }
        
        [JsonProperty("d1neerslag")]
        public string PrecipitationProbDay1{ get; set; }
        
        [JsonProperty("d1zon")]
        public string SunChanceDay1{ get; set; }

        [JsonProperty("d2tmax")]
        public string MaxTempDay2{ get; set; }
        
        [JsonProperty("d2tmin")]
        public string MinTempDay2{ get; set; }
        
        [JsonProperty("d2weer")]
        public string WeatherIconDay2{ get; set; }
        
        [JsonProperty("d2windk")]
        public string WindForceDay2{ get; set; }
        
        [JsonProperty("d2windr")]
        public string WindDirectionDay2{ get; set; }
        
        [JsonProperty("d2neerslag")]
        public string PrecipitationProbDay2{ get; set; }
        
        [JsonProperty("d2zon")]
        public string SunChanwceDay2{ get; set; }
        
        public string Alarm{ get; set; }
        
        public string Alarmtxt{ get; set; }

    }
}