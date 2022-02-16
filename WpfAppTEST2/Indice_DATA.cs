using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTEST2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class MVDA
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class MVDALC
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class MVDAMC
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class MVDASC
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class BTCA
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class BVIN
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class BTCB
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class ETHB
    {
        public string name { get; set; }
        public string description { get; set; }
        public string quote_currency { get; set; }
        public string index_market_name { get; set; }
        public string index_market_underlying_name { get; set; }
        public int day_close_in_seconds { get; set; }
    }

    public class Data3
    {
        public MVDA MVDA { get; set; }
        public MVDALC MVDALC { get; set; }
        public MVDAMC MVDAMC { get; set; }
        public MVDASC MVDASC { get; set; }
        public BTCA BTCA { get; set; }
        public BVIN BVIN { get; set; }
        public BTCB BTCB { get; set; }
        public ETHB ETHB { get; set; }
    }

    public class IndiceDATA
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public bool HasWarning { get; set; }
        public int Type { get; set; }
        public RateLimit RateLimit { get; set; }
        public Data3 Data { get; set; }
    }


    class Indice_DATA
    {

        public static async Task<IndiceDATA> GetIndice_DATAAsync(string path)
        {
            HttpClient client = new HttpClient();
            IndiceDATA product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<IndiceDATA>();
            }
            return product;
        }


        public static async Task<IndiceDATA> RunAsyncIndice()
        {

            IndiceDATA indices = null;

            try
            {

                indices = await GetIndice_DATAAsync("https://min-api.cryptocompare.com/data/index/list");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return indices;
        }
    }
}
