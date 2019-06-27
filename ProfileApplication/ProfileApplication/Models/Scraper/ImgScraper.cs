using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ProfileApplication.Helpers.Scraper
{
    public class ImgScraper : Scraper
    {
        public ImgScraper(string url, string className)
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
                List<string> srcs = new List<string>();

                foreach (var node in nodes)
                {
                    srcs.Add(node.SelectSingleNode("img").GetAttributeValue("src",""));
                }

                result = srcs;
            }
            catch
            {
                Console.WriteLine("Something went wrong during the scraping process");
            }
            return result;
        }
    }
}