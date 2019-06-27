using System;
using System.Collections.Generic;

namespace ProfileApplication.Helpers.Scraper
{
    public interface IScraper
    {
        List<String> Scrape();
    }
}