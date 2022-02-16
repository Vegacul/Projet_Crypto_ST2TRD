using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace WpfAppTEST2.Views
{
    /// <summary>
    /// Logique d'interaction pour Histo_Chart_View.xaml
    /// </summary>
    /// 

    public partial class Histo_Chart_View : UserControl
    {
        static HttpClient client = new HttpClient();


        public Histo_Chart_View()
        {
            InitializeComponent();
            Uri initUri = new Uri("https://min-api.cryptocompare.com/data/v2/histominute?fsym=BTC&tsym=USD&Limit=1440&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");
            this.AskDataHistoMinute(initUri, 1);
            this.AskDatacurrent("https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=BTC,USD,EUR&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WpfPlot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void AskDataHistoMinute(Uri URL, int days)
        {
            Historique_DATA histo = null;
            histo = await Histo_DATA.GetHisto_DATAAsync(URL.AbsoluteUri);
            days = -days;

            List<double> yValues = new List<double>();

            if (histo.Data.Data != null)
            {
                foreach (var item in histo.Data.Data)
                {
                    //Console.WriteLine(Histo_DATA.UnixTimeStampToDateTime(item.time) + " " + item.close);

                    yValues.Add(item.close);


                }

                double[] yValuesArray = yValues.ToArray();


                WpfPlot.Reset();
                var plt = WpfPlot.Plot;
                DateTime today = DateTime.Now;
                DateTime start = today.AddDays(days);
                double pointsPerDay = 24 * 60;
                var sig = plt.AddSignal(yValuesArray, pointsPerDay);
                sig.OffsetX = start.ToOADate();



                plt.XAxis.DateTimeFormat(true);
                plt.YAxis.Label("Price");
                plt.XAxis.Label("Date and Time");
                plt.XAxis2.Label("CryptoCurrency Price");
                WpfPlot.Refresh();
            }
            else
            {
                WpfPlot.Reset();
                var plt = WpfPlot.Plot;
                plt.XAxis2.Label("We doesn't find this currency Price");
                WpfPlot.Refresh();
            }

        }

        private async void AskDataHistoHour(Uri URL, int days)
        {
            Historique_DATA histo = null;
            histo = await Histo_DATA.GetHisto_DATAAsync(URL.AbsoluteUri);
            days = -days;

            List<double> yValues = new List<double>();

            if (histo.Data.Data != null)
            {
                foreach (var item in histo.Data.Data)
                {
                    //Console.WriteLine(Histo_DATA.UnixTimeStampToDateTime(item.time) + " " + item.close);

                    yValues.Add(item.close);


                }

                double[] yValuesArray = yValues.ToArray();


                WpfPlot.Reset();
                var plt = WpfPlot.Plot;
                DateTime today = DateTime.Now;
                DateTime start = today.AddDays(days);
                double pointsPerDay = 24 ;
                var sig = plt.AddSignal(yValuesArray, pointsPerDay);
                sig.OffsetX = start.ToOADate();



                plt.XAxis.DateTimeFormat(true);
                plt.YAxis.Label("Price");
                plt.XAxis.Label("Date and Time");
                plt.XAxis2.Label("CryptoCurrency Price");
                WpfPlot.Refresh();
            }
            else
            {
                WpfPlot.Reset();
                var plt = WpfPlot.Plot;
                plt.XAxis2.Label("We doesn't find this currency Price");
                WpfPlot.Refresh();
            }
        }

        private async void AskDatacurrent(string path)
        {

            Crypto_Price current;
            current = await Curent_DATA.GetProductAsync(path);
            BTCPrice.Content = current.BTC.ToString();
            USDPrice.Content = current.USD.ToString();
            EURPrice.Content = current.EUR.ToString();

        }


        private void Button1D_Click(object sender, RoutedEventArgs e)
        {

            Uri baseUri = new Uri("https://min-api.cryptocompare.com");


            Uri LocalPath = new Uri(baseUri, "/data/v2/histominute");

            //https://min-api.cryptocompare.com/data/v2/histominute?fsym=BTC&tsym=GBP&Limit=5000&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}

            Uri SubQueryTest = new Uri(LocalPath, ("?fsym=" + ASSET1.Text + "&tsym=" + ASSET2.Text + "&limit=1440&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}"));

            label1.Content = ASSET1.Text;
            label2.Content = ASSET2.Text;
            this.AskDataHistoMinute(SubQueryTest,1);

            this.AskDatacurrent("https://min-api.cryptocompare.com/data/price?fsym=" + ASSET1.Text + "&tsyms=BTC,USD,EUR&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");

        }


        private void Button7D_Click(object sender, RoutedEventArgs e)
        {

            Uri baseUri = new Uri("https://min-api.cryptocompare.com");


            Uri LocalPath = new Uri(baseUri, "/data/v2/histohour");

            //https://min-api.cryptocompare.com/data/v2/histohour?fsym=BTC&tsym=USD&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}

            Uri SubQueryTest = new Uri(LocalPath, ("?fsym=" + ASSET1.Text + "&tsym=" + ASSET2.Text + "&limit=168&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}"));



            label1.Content = ASSET1.Text;
            label2.Content = ASSET2.Text;
            this.AskDataHistoHour(SubQueryTest,7);
            this.AskDatacurrent("https://min-api.cryptocompare.com/data/price?fsym=" + ASSET1.Text + "&tsyms=BTC,USD,EUR&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");

        }

        private void Button14D_Click(object sender, RoutedEventArgs e)
        {

            Uri baseUri = new Uri("https://min-api.cryptocompare.com");


            Uri LocalPath = new Uri(baseUri, "/data/v2/histohour");

            //"https://min-api.cryptocompare.com/data/histoday?fsym=ETH&tsym=BTC&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");

            Uri SubQueryTest = new Uri(LocalPath, ("?fsym=" + ASSET1.Text + "&tsym=" + ASSET2.Text + "&limit=336&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}"));

            label1.Content = ASSET1.Text;
            label2.Content = ASSET2.Text;
            this.AskDataHistoHour(SubQueryTest,14);
            this.AskDatacurrent("https://min-api.cryptocompare.com/data/price?fsym=" + ASSET1.Text + "&tsyms=BTC,USD,EUR&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");

        }

        private void Button1M_Click(object sender, RoutedEventArgs e)
        {

            Uri baseUri = new Uri("https://min-api.cryptocompare.com");


            Uri LocalPath = new Uri(baseUri, "/data/v2/histohour");

            //"https://min-api.cryptocompare.com/data/histoday?fsym=ETH&tsym=BTC&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");

            Uri SubQueryTest = new Uri(LocalPath, ("?fsym=" + ASSET1.Text + "&tsym=" + ASSET2.Text + "&limit=720&aggregate=1&e=CCCAGG&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}"));

            label1.Content = ASSET1.Text;
            label2.Content = ASSET2.Text;
            this.AskDataHistoHour(SubQueryTest,30);
            this.AskDatacurrent("https://min-api.cryptocompare.com/data/price?fsym=" + ASSET1.Text + "&tsyms=BTC,USD,EUR&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");

        }
    }
}
