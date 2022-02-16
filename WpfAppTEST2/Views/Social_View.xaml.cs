using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppTEST2.Views
{
    /// <summary>
    /// Logique d'interaction pour Social_View.xaml
    /// </summary>
    public partial class Social_View : UserControl
    {
        static HttpClient client = new HttpClient();
        public Social_View()
        {
            InitializeComponent();
            Uri InitUri = new Uri("https://min-api.cryptocompare.com/data/social/coin/latest?coinId=1182&api_key=7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6");
            AskDataSocial(InitUri);
            //7605 ETH
        }
/*
        private async void AskDataCoinID(Uri URL)
        {

            CoinListDATA coin;
            coin = await CoinList_DATA.GetCoinAsync(URL.AbsoluteUri);
            List<string> coinidValue = new List<string>();

            foreach (var item in coin.Data)
            {
                //Console.WriteLine(Histo_DATA.UnixTimeStampToDateTime(item.time) + " " + item.close);

                coinidValue.Add(item.id);

            }
            string[] yValuesArray = coinidValue.ToArray();

            CoinID_find.Content = yValuesArray[0];


        }*/

        private async void AskDataSocial(Uri URL)
        {
            SocialData social = null;
            social = await Social_DATA.GetSocialAsync(URL.AbsoluteUri);

            if ((social.Data.Facebook != null) | (social.Data.Reddit != null) | (social.Data.Twitter != null) | (social.Data.CryptoCompare != null))
            {
                LabelPointsFB.Content = social.Data.Facebook.Points;
                Label2FB.Content = social.Data.Facebook.likes;
                Label3FB.Content = social.Data.Facebook.talking_about;

                LabelPointsReddit.Content = social.Data.Reddit.Points;
                Label2Reddit.Content = social.Data.Reddit.subscribers;
                Label3Reddit.Content = social.Data.Reddit.posts_per_day;

                LabelPointsCryptoC.Content = social.Data.Twitter.Points;
                Label2CryptoC.Content = social.Data.Twitter.followers;
                Label3CryptoC.Content = social.Data.Twitter.statuses;

                LabelPointsTwitter.Content = social.Data.CryptoCompare.Points;
                Label2Twitter.Content = social.Data.CryptoCompare.Followers;
                Label3Twitter.Content = social.Data.CryptoCompare.Posts;
            }
            else
            {
                LabelPointsFB.Content = "No DATA";
                Label2FB.Content = "No DATA";
                Label3FB.Content = "No DATA";

                LabelPointsReddit.Content = "No DATA";
                Label2Reddit.Content = "No DATA";
                Label3Reddit.Content = "No DATA";

                LabelPointsCryptoC.Content = "No DATA";
                Label2CryptoC.Content = "No DATA";
                Label3CryptoC.Content = "No DATA";

                LabelPointsTwitter.Content = "No DATA";
                Label2Twitter.Content = "No DATA";
                Label3Twitter.Content = "No DATA";
            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
/*            Uri baseUri1 = new Uri("https://min-api.cryptocompare.com");


            Uri LocalPath1 = new Uri(baseUri1, "/data/all/coinlist");

            Uri SubQueryTest1 = new Uri(LocalPath1, ("?fsym=" + CoinName.Text ));


            this.AskDataCoinID(SubQueryTest1);*/

            Uri baseUri = new Uri("https://min-api.cryptocompare.com");


            Uri LocalPath = new Uri(baseUri, "/data/social/coin/latest");

            Uri SubQueryTest = new Uri(LocalPath, ("?coinId=" + CoinID.Text + "&api_key=7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6"));


            this.AskDataSocial(SubQueryTest);
        }

        private void CoinName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
