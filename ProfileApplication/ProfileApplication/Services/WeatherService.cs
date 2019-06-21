using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using ProfileApplication.Helper;
using ProfileApplication.Models;

namespace ProfileApplication.Services
{
    public class WeatherService
    {
        public string GetWeatherInfo(string location)
        {
            string urlHead = "http://weerlive.nl/api/json-data-10min.php?key=3e65790d54&locatie=";
            string fullUrl = urlHead + location;
            
            using (WebClient httpClient = new WebClient())
            {
                string jsonData = httpClient.DownloadString(fullUrl);
                WeatherRoot weatherRoot = JsonConvert.DeserializeObject<WeatherRoot>(jsonData);
                WeatherInfo weatherInfo = weatherRoot.WeatherArr[0];
                
                SerializationHelper serializationHelper = new SerializationHelper();
                string serializedWeatherInfo = serializationHelper.Serialize(weatherInfo, true);
                return serializedWeatherInfo;
            }
        }
    }
}