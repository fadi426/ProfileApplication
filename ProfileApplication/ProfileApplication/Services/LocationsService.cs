using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using ProfileApplication.Helper;
using ProfileApplication.Models;
using ProfileApplication.Models.Places;

namespace ProfileApplication.Services
{
    public class LocationsService
    {
        public string GetPlaceInfo()
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
        
        public List<Locations> GetLocationNames()
        {
            string fullUrl = "https://opendata.cbs.nl/ODataApi/OData/80477ned/PlaatsEnGemeentenamen";
            
            using (WebClient httpClient = new WebClient())
            {
                string jsonData = httpClient.DownloadString(fullUrl);
                LocationsRoot locationsRoot = JsonConvert.DeserializeObject<LocationsRoot>(jsonData);
                
                List<Locations> locations = locationsRoot.Locations.ToList();
                return locations;
            }
        }
    }
}