using System;
using System.Net;
using Newtonsoft.Json;
using ProfileApplication.Models.News;

namespace ProfileApplication.Services
{
    public class NewsService
    {
        public static string GetNews(string location)
        {
            DateTime today = DateTime.Today;
            const string urlHead = "https://newsapi.org/v2/everything?q=";
            string urlTail = "&from=" + today.ToString("d") +"&sortBy=publishedAt&apiKey=03e253a3a3ac4742902811c93c4b66c4";
            string fullUrl = urlHead + location + urlTail;

            using (WebClient httpClient = new WebClient())
            {
                string jsonData = httpClient.DownloadString(fullUrl);
                News news = JsonConvert.DeserializeObject<News>(jsonData);
                string result = JsonConvert.SerializeObject(news);
                return result;
            }
        }
    }
}