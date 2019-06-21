using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileApplication.Models;
using ProfileApplication.Services;

namespace ProfileApplication.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly WeatherService _weatherService = new WeatherService();
        private readonly PlacesService _placesService = new PlacesService();

        // GET api/profile/weather
        [HttpGet("weather/{id}")]
        public ActionResult<string> GetWeatherInfo(string id)
        {
            return _weatherService.GetWeatherInfo(id);
        }
        
        // GET api/profile/weather
        [HttpGet("places")]
        public ActionResult<string> GetPlaces()
        {
            return _placesService.GetPlaceInfo();
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