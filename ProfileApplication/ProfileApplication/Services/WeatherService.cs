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
        public static string GetWeather(string location)
        {
            const string urlHead = "http://weerlive.nl/api/json-data-10min.php?key=3e65790d54&locatie=";
            string fullUrl = urlHead + location;
            
            using (WebClient httpClient = new WebClient())
            {
                string jsonData = httpClient.DownloadString(fullUrl);
                WeatherRoot weatherRoot = JsonConvert.DeserializeObject<WeatherRoot>(jsonData);
                Weather weather = weatherRoot.WeatherArr[0];
                
                SerializationHelper serializationHelper = new SerializationHelper();
                string result = serializationHelper.Serialize(weather, true);
                return result;
            }
        }
    }
}