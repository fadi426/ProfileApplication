using System.Net;
using Newtonsoft.Json;
using ProfileApplication.Models.News;

namespace ProfileApplication.Services
{
    public class NewsService
    {
        public static string GetNews(string location)
        {
            const string urlHead = "https://newsapi.org/v2/everything?q=";
            const string urlTail = "&from=2019-05-25&sortBy=publishedAt&apiKey=03e253a3a3ac4742902811c93c4b66c4";
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