using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using HtmlAgilityPack;

namespace ProfileApplication.Helpers.Scraper
{
    public class HrefScraper : Scraper
    {
        public HrefScraper(string url, string className)
        {
            this.Url = url;
            this.ClassName = className;
        }
        
        public override List<string> Scrape()
        {
            List<string> result = new List<string>();
            try
            {
                //Get the content of the URL from the Web
                var web = new HtmlWeb();
                var doc = web.Load(Url);


                //Filter the content
                doc.DocumentNode.Descendants()
                    .Where(n => n.Name == "script")
                    .ToList()
                    .ForEach(n => n.Remove());

                var nodes = doc.DocumentNode.SelectNodes($"//*[@class='{ClassName}']");
                
                //Scrape the hrefs of the element
                var hrefs = nodes.Descendants("a")
                    .Select(node => node.GetAttributeValue("href","")) 
                    .ToList();

                if (hrefs.Count == 0)
                {
                    foreach (var node in nodes)
                    {
                        hrefs.Add(node.GetAttributeValue("href", ""));
                    }
                }
                result = hrefs.Distinct().ToList();
            }
            catch
            {
                Console.WriteLine("Something went wrong during the scraping process");
            }
            return result;
        }
    }
}