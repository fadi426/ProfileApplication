using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProfileApplication.Models;
using ProfileApplication.Services;

namespace ProfileApplication.Controllers
{
    [Route("api/profile")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly WeatherService _weatherService = new WeatherService();
        private readonly LocationsService _locationsService = new LocationsService();

        // GET api/profile/locations
        [HttpGet("locations")]
        public ActionResult<string> GetLocations()
        {
            return _locationsService.GetLocations();
        }
        
        // GET api/profile/locations/(location)
        [HttpGet("locations/{id}")]
        public ActionResult<string> GetPlaces(string id)
        {
            return _locationsService.GetLocation(id);
        }
        
        // GET api/profile/locations/(location)/weather
        [HttpGet("locations/{id}/weather")]
        public ActionResult<string> GetWeatherInfo(string id)
        {
            return WeatherService.GetWeather(id);
        }
        
        // GET api/profile/locations/(location)/news
        [HttpGet("locations/{id}/news")]
        public ActionResult<string> GetNews(string id)
        {
            return NewsService.GetNews(id);
        }
        
        // GET api/profile/locations/(location)/events
        [HttpGet("locations/{id}/events")]
        public ActionResult<string> GetEvents(string id)
        {
            return EventService.GetEvents(id);
        }
        
        // GET api/profile/locations/(location)/movies
        [HttpGet("locations/{id}/movies")]
        public ActionResult<string> GetMovies(string id)
        {
            return MoviesService.GetMovies(id);
        }
    }
}