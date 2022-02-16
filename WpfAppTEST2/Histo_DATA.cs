using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace WpfAppTEST2
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class RateLimit
    {
    }

    public class Datum
    {
        public int time { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double open { get; set; }
        public double volumefrom { get; set; }
        public double volumeto { get; set; }
        public double close { get; set; }
        public string conversionType { get; set; }
        public string conversionSymbol { get; set; }
    }

    public class DataMain
    {
        public bool Aggregated { get; set; }
        public int TimeFrom { get; set; }
        public int TimeTo { get; set; }
        public List<Datum> Data { get; set; }
    }

    public class Historique_DATA
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public bool HasWarning { get; set; }
        public int Type { get; set; }
        public RateLimit RateLimit { get; set; }
        public DataMain Data { get; set; }
    }
    public class Histo_DATA
    {

        public static async Task<Historique_DATA> GetHisto_DATAAsync(string path)
        {
            HttpClient client = new HttpClient();
            Historique_DATA product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Historique_DATA>();
            }
            return product;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static async Task<Historique_DATA> RunAsyncHisto()
        {

            Historique_DATA histo = null;

            try
            {
                //Uri baseUri = new Uri("https://min-api.cryptocompare.com/data/histominute?fsym=ETH&tsym=USD&aggregate=1&e=CCCAGG");
                //Uri myUri = new Uri(baseUri, "&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");
                //Console.WriteLine(myUri.AbsoluteUri);

                histo = await GetHisto_DATAAsync("https://min-api.cryptocompare.com/data/histoday?fsym=ETH&tsym=BTC&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return histo;
        }
    }
}