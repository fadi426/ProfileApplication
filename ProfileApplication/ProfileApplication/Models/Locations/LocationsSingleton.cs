using System.Collections.Generic;

namespace ProfileApplication.Models.Places
{
    public class LocationsSingleton
    {
        private static LocationsSingleton _instance;

        private LocationsSingleton() {}

        public static LocationsSingleton Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new LocationsSingleton();
                }
                return _instance;
            }
        }

        public string Locations { get; set; }        

    }
}