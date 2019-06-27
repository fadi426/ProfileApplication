using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProfileApplication.Models.Events;

namespace ProfileApplication.Helpers.Scraper
{
    public class ElementScraper : Scraper
    {
        public ElementScraper(string url, string className)
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

                var nodes = doc.DocumentNode.SelectNodes($"//*[@class='{ClassName}']") ?? Enumerable.Empty<HtmlNode>();
                
                foreach (var node in nodes)
                {
                    var splittedWords = Regex.Split(node.InnerText, "\n");
                    var words = splittedWords
                        .Where(x => !x.Contains("&nbsp;") && !string.IsNullOrEmpty(x.Trim()))
                        .ToList();

                    result.Add(words[0].Replace("amp;", ""));
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong during the scraping process");
            }
            return result;
        }
    }
}