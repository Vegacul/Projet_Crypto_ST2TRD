using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WpfAppTEST2
{
    public class Crypto_Price
    {
        public double BTC { get; set; }
        public double EUR { get; set; }
        public double USD { get; set; }

    }

    public class Curent_DATA
    {
        static HttpClient client = new HttpClient();


        public static async Task<Crypto_Price> GetProductAsync(string path)
        {
            Crypto_Price product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Crypto_Price>();
            }
            return product;
        }

        public static async Task RunAsyncCurrent()
        {

            try
            {
                Crypto_Price test;

                Uri baseUri = new Uri("https://min-api.cryptocompare.com/data/histohour?fsym=BTC&tsym=ETH&aggregate=1&e=CCCAGG");
                Uri myUri = new Uri(baseUri, "&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");
                Console.WriteLine(myUri.AbsoluteUri);
                // Get the product

                test = await GetProductAsync("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=BTC,USD,EUR&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}