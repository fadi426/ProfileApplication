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
            //scrapes the current and upcoming events of the location
            string urlHead = "https://www.ticketmaster.nl/search/?keyword=";
            string fullUrl = urlHead + location;
            string className = "sc-17c7lsa-1 iMroit";
            
            //scrape the needed info for the Event object
            HrefScraper hrefScraper = new HrefScraper(fullUrl, className);
            List<string> hrefList = hrefScraper.Scrape();
            
            ElementContentScraper elementContentScraper = new ElementContentScraper(fullUrl, className);
            List<string> elementList = elementContentScraper.Scrape();
            
            List<Event> eventList = new List<Event>();
            Regex htmlRegex = new Regex(@"((\w*?\d*\s\d*:\d*.*)( -))");
            Regex eventRegex = new Regex(@"(\w*)(\d\d)(\w*)(\s)(\d*:\d*)(.*)");

            //build the Event object with the scrapers result value's
            for (int i = 0; i < elementList.Count; i++)
            {
                string element = elementList[i];
                
                Match match = htmlRegex.Match(element);

                string eventString = match.Groups[2].Value;
                match = eventRegex.Match(eventString);

                Event eventObj = new Event();
                eventObj.WeekDay = match.Groups[3].Value;
                eventObj.Day = match.Groups[2].Value;
                eventObj.Month = match.Groups[1].Value;
                eventObj.Time = match.Groups[5].Value;
                eventObj.Title = match.Groups[6].Value;
                eventObj.Url = hrefList[i];
                
                // scrape the image of the event from the href link
                ImgScraper imageScraper = new ImgScraper(hrefList[i], "vhbo54-1 dvQcM");
                List<string> images = imageScraper.Scrape();
                if (images.Count > 0)
                    eventObj.UrlToImage = images[0];
                else
                    eventObj.UrlToImage = "";

                eventList.Add(eventObj);
            }

            //convert the Event object to json
            string result = JsonConvert.SerializeObject(eventList);
            return result;
        }
    }
}