using System.Collections.Generic;

namespace ProfileApplication.Helpers.Scraper
{
    public abstract class Scraper : IScraper
    {
        public string Url { get; set;}
        public string ClassName { get; set; }

        public abstract List<string> Scrape();
    }
}