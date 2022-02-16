using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTEST2
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


    public class General
    {
        public int Points { get; set; }
        public string Name { get; set; }
        public string CoinName { get; set; }
        public string Type { get; set; }
    }

    public class PageViewsSplit
    {
        public int Overview { get; set; }
        public int Markets { get; set; }
        public int Analysis { get; set; }
        public int Charts { get; set; }
        public int Trades { get; set; }
        public int Orderbook { get; set; }
        public int Forum { get; set; }
        public int Influence { get; set; }
        public int News { get; set; }
        public int Timeline { get; set; }
    }

    public class CryptoCompare
    {
        public int Points { get; set; }
        public int Followers { get; set; }
        public int Posts { get; set; }
        public List<object> SimilarItems { get; set; }
        public int Comments { get; set; }
        public PageViewsSplit PageViewsSplit { get; set; }
        public int PageViews { get; set; }
        public List<object> CryptopianFollowers { get; set; }
    }

    public class Twitter
    {
        public int Points { get; set; }
        public string account_creation { get; set; }
        public int followers { get; set; }
        public int statuses { get; set; }
        public string link { get; set; }
        public int lists { get; set; }
        public int favourites { get; set; }
        public int following { get; set; }
        public string name { get; set; }
    }

    public class Reddit
    {
        public int Points { get; set; }
        public double posts_per_hour { get; set; }
        public double comments_per_hour { get; set; }
        public double comments_per_day { get; set; }
        public int active_users { get; set; }
        public string link { get; set; }
        public string community_creation { get; set; }
        public double posts_per_day { get; set; }
        public string name { get; set; }
        public int subscribers { get; set; }
    }

    public class Facebook
    {
        public string Points { get; set; }
        public int talking_about { get; set; }
        public bool is_closed { get; set; }
        public string likes { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class InternalData
    {
    }

    public class Parent
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int InternalId { get; set; }
        public InternalData InternalData { get; set; }
    }

    public class Source
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int InternalId { get; set; }
        public InternalData InternalData { get; set; }
    }

    public class List
    {
        public int forks { get; set; }
        public string last_update { get; set; }
        public int open_total_issues { get; set; }
        public int subscribers { get; set; }
        public bool fork { get; set; }
        public int closed_pull_issues { get; set; }
        public Parent parent { get; set; }
        public int open_pull_issues { get; set; }
        public int stars { get; set; }
        public int closed_issues { get; set; }
        public string url { get; set; }
        public int contributors { get; set; }
        public string created_at { get; set; }
        public int open_issues { get; set; }
        public Source source { get; set; }
        public int closed_total_issues { get; set; }
        public int size { get; set; }
        public string last_push { get; set; }
    }

    public class CodeRepository
    {
        public List<List> List { get; set; }
        public int Points { get; set; }
    }

    public class Data
    {
        public General General { get; set; }
        public CryptoCompare CryptoCompare { get; set; }
        public Twitter Twitter { get; set; }
        public Reddit Reddit { get; set; }
        public Facebook Facebook { get; set; }
        public CodeRepository CodeRepository { get; set; }
    }

    public class SocialData
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public bool HasWarning { get; set; }
        public int Type { get; set; }
        public RateLimit RateLimit { get; set; }
        public Data Data { get; set; }
    }


    public class Social_DATA
    {
        static HttpClient client = new HttpClient();

        public static async Task<SocialData> GetSocialAsync(string path)
        {
            SocialData product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<SocialData>();
            }
            return product;
        }

        public static async Task<SocialData> RunAsyncSocial(string CoinID)
        {
            SocialData social = null;
            try
            {


                Uri baseUri = new Uri("https://min-api.cryptocompare.com");


                Uri LocalPath = new Uri(baseUri, "/data/social/coin/latest");

                Uri SubQueryTest = new Uri(LocalPath, ("?coinId=" + CoinID + "&api_key=7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6"));

                // Get the product
                //https://min-api.cryptocompare.com/data/social/coin/latest?coinId=1182&api_key=7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6

                //Console.WriteLine(SubQueryTest.AbsoluteUri);
                social = await GetSocialAsync(SubQueryTest.AbsoluteUri);
                
                return social;



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return social;


        }
    }
}
