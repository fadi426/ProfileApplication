using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProfileApplication.Helper;
using ProfileApplication.Models;
using ProfileApplication.Models.Places;

namespace ProfileApplication.Services
{
    public class LocationsService
    {
        public string GetLocations()
        {
            LocationsSingleton locationsSingleton = LocationsSingleton.Instance;
            string locations = locationsSingleton.Locations;
            if (locations != null)
            {
                return locations;
            }
            
            SerializationHelper serializationHelper = new SerializationHelper();
            List<Locations> locationArr = GetLocationNames();
            string serializedLocations = serializationHelper.Serialize(locationArr, true);
            locationsSingleton.Locations = serializedLocations;
            
            return serializedLocations;
        }
        
        private static List<Locations> GetLocationNames()
        {
            const string fullUrl = "https://opendata.cbs.nl/ODataApi/OData/80477ned/PlaatsEnGemeentenamen";
            
            using (WebClient httpClient = new WebClient())
            {
                string jsonData = httpClient.DownloadString(fullUrl);
                LocationsRoot locationsRoot = JsonConvert.DeserializeObject<LocationsRoot>(jsonData);
                
                List<Locations> locations = locationsRoot.Locations.ToList();
                return locations;
            }
        }

        public string GetLocation(string location)
        {
            const string urlHead = "https://eu1.locationiq.com/v1/search.php?key=36a3bf33f47a91&q=";
            const string urlTail = "&format=json";
            string fullUrl = urlHead + location + urlTail;
            using (WebClient httpClient = new WebClient())
            {
                var nameString = "";
                string jsonData = httpClient.DownloadString(fullUrl);
                dynamic jsonArr = JArray.Parse(jsonData);
                nameString = jsonArr[0].display_name;
                Location l = new Location();
                l.Name = location;
                l.Province = FindProvince(nameString);
                l.Country = FindCountry(nameString);
                l.Latitude = jsonArr[0].lat;
                l.Longitude = jsonArr[0].lon;

                string result = Newtonsoft.Json.JsonConvert.SerializeObject(l);
                return result;
            }
        }

        private static string FindProvince(string locationString)
        {
            Regex regex = new Regex(@"(\w*)(,\W\d*)?(\W*)?,?\W?(\b(\w+)\W*$)");
            Regex regexZip = new Regex(@"(\w*)(,\W\w*)(,\W\d*),?\W?(\b(\w+)\W*$)");
            Match match;

            if (!locationString.Any(char.IsDigit)){
                match = regex.Match(locationString);
                if (locationString.Contains(","))
                    return match.Groups[1].Value;
                return match.Groups[5].Value;
            }
            match = regexZip.Match(locationString);
            return match.Groups[1].Value;
        }
        
        private static string FindCountry(string locationString)
        {
            Regex regex = new Regex(@"(\w*$)");
            Match match = regex.Match(locationString);
            return match.Groups[1].Value;
        }
    }
}