using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTEST2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Taxonomy
    {
        public string Access { get; set; }
        public string FCA { get; set; }
        public string FINMA { get; set; }
        public string Industry { get; set; }
        public string CollateralizedAsset { get; set; }
        public string CollateralizedAssetType { get; set; }
        public string CollateralType { get; set; }
        public string CollateralInfo { get; set; }
    }

    public class Weiss
    {
        public string Rating { get; set; }
        public string TechnologyAdoptionRating { get; set; }
        public string MarketPerformanceRating { get; set; }
    }

    public class Rating
    {
        public Weiss Weiss { get; set; }
    }

    public class BTC
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public int ContentCreatedOn { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string CoinName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string AssetTokenStatus { get; set; }
        public string Algorithm { get; set; }
        public string ProofType { get; set; }
        public string SortOrder { get; set; }
        public bool Sponsored { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public Rating Rating { get; set; }
        public bool IsTrading { get; set; }
        public int TotalCoinsMined { get; set; }
        public int CirculatingSupply { get; set; }
        public int BlockNumber { get; set; }
        public string NetHashesPerSecond { get; set; }
        public double BlockReward { get; set; }
        public int BlockTime { get; set; }
        public string AssetLaunchDate { get; set; }
        public string AssetWhitepaperUrl { get; set; }
        public string AssetWebsiteUrl { get; set; }
        public double MaxSupply { get; set; }
        public int MktCapPenalty { get; set; }
        public int IsUsedInDefi { get; set; }
        public int IsUsedInNft { get; set; }
        public string PlatformType { get; set; }
        public int DecimalPoints { get; set; }
        public string AlgorithmType { get; set; }
        public long Difficulty { get; set; }
    }

    public class Data4
    {
        public BTC BTC { get; set; }
    }


    public class CoinListDATA
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public Data4 Data { get; set; }
        public RateLimit RateLimit { get; set; }
        public bool HasWarning { get; set; }
        public int Type { get; set; }
    }



    class CoinList_DATA
    {

        static HttpClient client = new HttpClient();


        public static async Task<CoinListDATA> GetCoinAsync(string path)
        {
            CoinListDATA Coin = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                Coin = await response.Content.ReadAsAsync<CoinListDATA>();
            }
            return Coin;
        }
    }
}
