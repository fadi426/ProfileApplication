using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using ProfileApplication.Helper;
using ProfileApplication.Models;
using ProfileApplication.Models.Places;

namespace ProfileApplication.Services
{
    public class PlacesService
    {
        public string GetPlaceInfo()
        {
            PlacesSingleton placesSingleton = PlacesSingleton.Instance;
            string places = placesSingleton.Places;
            if (places != null)
            {
                return places;
            }
            SerializationHelper serializationHelper = new SerializationHelper();
            List<Places> placesArr = GetPlaceNames();
            string serializedPlaces = serializationHelper.Serialize(placesArr, true);
            placesSingleton.Places = serializedPlaces;
            return serializedPlaces;
        }
        
        public List<Places> GetPlaceNames()
        {
            string fullUrl = "https://opendata.cbs.nl/ODataApi/OData/80477ned/PlaatsEnGemeentenamen";
            
            using (WebClient httpClient = new WebClient())
            {
                string jsonData = httpClient.DownloadString(fullUrl);
                PlaceRoot placeRoot = JsonConvert.DeserializeObject<PlaceRoot>(jsonData);
                
                List<Places> places = placeRoot.Places.ToList();
                return places;
            }
        }
    }
}