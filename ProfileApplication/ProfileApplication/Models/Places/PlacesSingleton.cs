using System.Collections.Generic;

namespace ProfileApplication.Models.Places
{
    public class PlacesSingleton
    {
        private static PlacesSingleton _instance;

        private PlacesSingleton() {}

        public static PlacesSingleton Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new PlacesSingleton();
                }
                return _instance;
            }
        }

        public string Places { get; set; }        

    }
}