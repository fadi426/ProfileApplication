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
        
        // GET api/profile/weather
        [HttpGet("locations/{id}/weather")]
        public ActionResult<string> GetWeatherInfo(string id)
        {
            return WeatherService.GetWeather(id);
        }
        
        // GET api/profile/locations/)
        [HttpGet("locations/{id}/news")]
        public ActionResult<string> GetNews(string id)
        {
            return NewsService.GetNews(id);
        }
        
        // GET api/profile/locations/)
        [HttpGet("locations/{id}/events")]
        public ActionResult<string> GetEvents(string id)
        {
            return EventService.GetEvents(id);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}