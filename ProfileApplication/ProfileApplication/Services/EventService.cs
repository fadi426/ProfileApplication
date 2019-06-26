using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ProfileApplication.Helpers.Scraper;
using ProfileApplication.Models.Events;
using ProfileApplication.Models.News;

namespace ProfileApplication.Services
{
    public class EventService
    {
        public static string GetEvents(string location)
        {
            string urlHead = "https://www.ticketmaster.nl/search/?keyword=";
            string fullUrl = urlHead + location;
            string className = "sc-17c7lsa-1 iMroit";
            Scraper scraper = new Scraper(fullUrl, className);
            List<Event> eventList = new List<Event>();

            Regex htmlRegex = new Regex(@"((\w*?\d*\s\d*:\d*.*)( -))");
            Regex eventRegex = new Regex(@"(\w*)(\d\d)(\w*)(\s)(\d*:\d*)(.*)");
            List<string> scraperList = scraper.WebDataScraper();

            foreach (var element in scraperList)
            {
                Match match = htmlRegex.Match(element);

                string eventString = match.Groups[2].Value;
                match = eventRegex.Match(eventString);

                Event eventObj = new Event();
                eventObj.WeekDay = match.Groups[3].Value;
                eventObj.Day = match.Groups[2].Value;
                eventObj.Month = match.Groups[1].Value;
                eventObj.Time = match.Groups[5].Value;
                eventObj.Title = match.Groups[6].Value;
                
                eventList.Add(eventObj);
            }


            string result = JsonConvert.SerializeObject(eventList);
            return result;
        }
    }
}