using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTEST2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class SourceInfo
    {
        public string name { get; set; }
        public string lang { get; set; }
        public string img { get; set; }
    }

    public class Datum2
    {
        public string id { get; set; }
        public string guid { get; set; }
        public int published_on { get; set; }
        public string imageurl { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string source { get; set; }
        public string body { get; set; }
        public string tags { get; set; }
        public string categories { get; set; }
        public string upvotes { get; set; }
        public string downvotes { get; set; }
        public string lang { get; set; }
        public SourceInfo source_info { get; set; }
    }



    public class newsData
    {
        public int Type { get; set; }
        public string Message { get; set; }
        public List<object> Promoted { get; set; }
        public List<Datum2> Data { get; set; }
        public RateLimit RateLimit { get; set; }
        public bool HasWarning { get; set; }
    }

    class News_DATA
    {
        static HttpClient client = new HttpClient();

        public static async Task<newsData> GetNewsAsync(string path)
        {
            newsData product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<newsData>();
            }
            return product;
        }

        public static async Task<newsData> RunAsyncNews()
        {
            newsData news = null;
            try
            {


                Uri baseUri = new Uri("https://min-api.cryptocompare.com");


                Uri LocalPath = new Uri(baseUri, "/data/v2/news/?lang=EN");

                Uri SubQueryTest = new Uri(LocalPath, ("&api_key=7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6"));

                news = await GetNewsAsync(SubQueryTest.AbsoluteUri);

                return news;



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return news;


        }
    }
}
