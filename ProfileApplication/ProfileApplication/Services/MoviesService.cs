using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProfileApplication.Helpers.Scraper;
using ProfileApplication.Models.Movies;

namespace ProfileApplication.Services
{
    public class MoviesService
    {
        public static string GetMovies(string location)
        {
            string fullUrl = "https://www.pathe.nl/films/actueel";
            string className = "poster poster--smaller";
            ElementScraper elementScraper = new ElementScraper(fullUrl, className);
            List<string> elementList = elementScraper.Scrape();
            
            HrefScraper hrefScraper = new HrefScraper(fullUrl, className);
            List<string> hrefList = hrefScraper.Scrape();
            
            ImgScraper imgScraper = new ImgScraper(fullUrl, "poster__image");
            List<string> imgList = imgScraper.Scrape();
            
            List<Movie> movieList = new List<Movie>();
            Regex movieNameRegex = new Regex(@"\s*(.*)");

            for (int i = 0; i < elementList.Count; i++)
            {
                string element = elementList[i];
                Movie movieObj = new Movie();

                Match match = movieNameRegex.Match(element);
                movieObj.Name = match.Groups[1].Value;
                movieObj.Url = "https://www.pathe.nl" + hrefList[i];
                movieObj.UrlToImage = imgList[i];
                
                movieList.Add(movieObj);
            }

            string result = JsonConvert.SerializeObject(movieList);
            return result;
        }
    }
}