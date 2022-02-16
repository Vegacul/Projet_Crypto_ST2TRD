
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTEST2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class InOutVar
    {
        public string category { get; set; }
        public string sentiment { get; set; }
        public double value { get; set; }
        public double score { get; set; }
        public double score_threshold_bearish { get; set; }
        public double score_threshold_bullish { get; set; }
    }

    public class LargetxsVar
    {
        public string category { get; set; }
        public string sentiment { get; set; }
        public double value { get; set; }
        public double score { get; set; }
        public double score_threshold_bearish { get; set; }
        public double score_threshold_bullish { get; set; }
    }

    public class AddressesNetGrowth
    {
        public string category { get; set; }
        public string sentiment { get; set; }
        public double value { get; set; }
        public double score { get; set; }
        public double score_threshold_bearish { get; set; }
        public double score_threshold_bullish { get; set; }
    }

    public class ConcentrationVar
    {
        public string category { get; set; }
        public string sentiment { get; set; }
        public double value { get; set; }
        public double score { get; set; }
        public double score_threshold_bearish { get; set; }
        public double score_threshold_bullish { get; set; }
    }

    public class Data2
    {
        public int id { get; set; }
        public int time { get; set; }
        public string symbol { get; set; }
        public string partner_symbol { get; set; }
        public InOutVar inOutVar { get; set; }
        public LargetxsVar largetxsVar { get; set; }
        public AddressesNetGrowth addressesNetGrowth { get; set; }
        public ConcentrationVar concentrationVar { get; set; }
    }

    public class TradingSignalData
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public bool HasWarning { get; set; }
        public int Type { get; set; }
        public RateLimit RateLimit { get; set; }
        public Data2 Data { get; set; }
    }

    class TradingSignal_DATA
    {
        static HttpClient client = new HttpClient();
        public static async Task<TradingSignalData> GetTradingSignalAsync(string path)
        {
            TradingSignalData product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<TradingSignalData>();
            }
            return product;
        }

        public static async Task RunAsyncTradingSignal()
        {

            try
            {

                TradingSignalData TSD = null;

                Uri baseUri = new Uri("https://min-api.cryptocompare.com");


                Uri LocalPath = new Uri(baseUri, "/data/tradingsignals/intotheblock/latest");

                Uri SubQueryTest = new Uri(LocalPath, ("?fsym=BTC&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}"));
                Console.WriteLine(SubQueryTest.AbsoluteUri);
                // https://min-api.cryptocompare.com/data/tradingsignals/intotheblock/latest?fsym=BTC

                TSD = await GetTradingSignalAsync(SubQueryTest.AbsoluteUri);

                Console.WriteLine("This momentum signal calculates the net change of in/out of the money addresses, if the number of In the Money addresses is increasing this would be a bullish signal. In the money means addresses that would make a profit on the tokens they hold because they acquired the tokens at a lower price.");
                Console.WriteLine(TSD.Data.inOutVar.score);
                Console.WriteLine("Momentum signal that is bullish when the short term trend of the number of txs > $100k is greater than the long term average.");
                Console.WriteLine(TSD.Data.largetxsVar.score);
                Console.WriteLine("Momentum signal that gives an indication of the tokens underlying network health by measuring the amount of new addresses minus the addresses that have their balances emptied. It is bullish when more addresses are being created than emptied.");
                Console.WriteLine(TSD.Data.addressesNetGrowth.score);
                Console.WriteLine("The Concentration signal is based on the accumulation (bullish) or reduction (bearish) of addresses with more than 0.1% of the circulating supply.");
                Console.WriteLine(TSD.Data.concentrationVar.score);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}


