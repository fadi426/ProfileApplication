using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProfileApplication.Models;

namespace ProfileApplication.Services
{
    public class WeatherService
    {
        private WeatherInfo[] WeatherInfos;

        public WeatherInfo GetWeatherInfo(string location)
        {
            string urlHead = "http://weerlive.nl/api/json-data-10min.php?key=3e65790d54&locatie=";
            string fullUrl = urlHead + location;
            
            using (WebClient httpClient = new WebClient())
            {
                string jsonData = httpClient.DownloadString(fullUrl);
                JObject obj = JObject.Parse(jsonData);
                var weatherArr = obj["liveweer"];
                WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(weatherArr[0].ToString());
                
                Console.Out.Write(weatherInfo);
                return weatherInfo;
            }
        }
    }
}