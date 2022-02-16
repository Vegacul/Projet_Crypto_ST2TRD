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
    /// Logique d'interaction pour Trading_Signal_View.xaml
    /// </summary>
    public partial class Trading_Signal_View : UserControl
    {
        static HttpClient client = new HttpClient();
        public Trading_Signal_View()
        {
            InitializeComponent();
            Uri InitUri = new Uri("https://min-api.cryptocompare.com/data/tradingsignals/intotheblock/latest?fsym=BTC&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}");
            AskDataTrading(InitUri);
        }

        private async void AskDataTrading(Uri URL)
        {

            TradingSignalData TSD = null;



            TSD = await TradingSignal_DATA.GetTradingSignalAsync(URL.AbsoluteUri);
            string up = "bullish";
            string down = "bearish";

            if ((TSD.Data.inOutVar != null) | (TSD.Data.inOutVar != null))
            {
                Signal1Score.Content = TSD.Data.inOutVar.score;
                Signal1Signal.Content = TSD.Data.inOutVar.sentiment;

                if (TSD.Data.inOutVar.sentiment.Contains(up))
                {
                    Signal1Signal.Foreground = new SolidColorBrush(Colors.Green);
                    Signal1Score.Foreground = new SolidColorBrush(Colors.Green);
                }
                else if (TSD.Data.inOutVar.sentiment.Contains(down))
                {
                    Signal1Signal.Foreground = new SolidColorBrush(Colors.Red);
                    Signal1Score.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    Signal1Signal.Foreground = new SolidColorBrush(Colors.Gold);
                    Signal1Score.Foreground = new SolidColorBrush(Colors.Gold);
                }


                Signal2Score.Content = TSD.Data.largetxsVar.score;
                Signal2Signal.Content = TSD.Data.largetxsVar.sentiment;

                if (TSD.Data.largetxsVar.sentiment.Contains(up))
                {
                    Signal2Signal.Foreground = new SolidColorBrush(Colors.Green);
                    Signal2Score.Foreground = new SolidColorBrush(Colors.Green);
                }
                else if (TSD.Data.largetxsVar.sentiment.Contains(down))
                {
                    Signal2Signal.Foreground = new SolidColorBrush(Colors.Red);
                    Signal2Score.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    Signal2Signal.Foreground = new SolidColorBrush(Colors.Gold);
                    Signal2Score.Foreground = new SolidColorBrush(Colors.Gold);

                }

                Signal3Score.Content = TSD.Data.addressesNetGrowth.score;
                Signal3Signal.Content = TSD.Data.addressesNetGrowth.sentiment;

                if (TSD.Data.addressesNetGrowth.sentiment.Contains(up))
                {
                    Signal3Signal.Foreground = new SolidColorBrush(Colors.Green);
                    Signal3Score.Foreground = new SolidColorBrush(Colors.Green);
                }
                else if (TSD.Data.addressesNetGrowth.sentiment.Contains(down))
                {
                    Signal3Signal.Foreground = new SolidColorBrush(Colors.Red);
                    Signal3Score.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    Signal3Signal.Foreground = new SolidColorBrush(Colors.Gold);
                    Signal3Score.Foreground = new SolidColorBrush(Colors.Gold);

                }

                Signal4Score.Content = TSD.Data.concentrationVar.score;
                Signal4Signal.Content = TSD.Data.concentrationVar.sentiment;
                if (TSD.Data.concentrationVar.sentiment.Contains(up))
                {
                    Signal4Signal.Foreground = new SolidColorBrush(Colors.Green);
                    Signal4Score.Foreground = new SolidColorBrush(Colors.Green);

                }
                else if (TSD.Data.concentrationVar.sentiment.Contains(down))
                {
                    Signal4Signal.Foreground = new SolidColorBrush(Colors.Red);
                    Signal4Score.Foreground = new SolidColorBrush(Colors.Red);

                }
                else
                {
                    Signal4Signal.Foreground = new SolidColorBrush(Colors.Gold);
                    Signal4Score.Foreground = new SolidColorBrush(Colors.Gold);


                }
            }
            else
            {
                Signal1Score.Content ="No DATA";
                Signal1Score.Foreground = new SolidColorBrush(Colors.DarkRed);

                Signal1Signal.Content = "No DATA";
                Signal1Signal.Foreground = new SolidColorBrush(Colors.DarkRed);

                Signal2Score.Content = "No DATA";
                Signal2Score.Foreground = new SolidColorBrush(Colors.DarkRed);

                Signal2Signal.Content = "No DATA";
                Signal2Signal.Foreground = new SolidColorBrush(Colors.DarkRed);

                Signal3Score.Content = "No DATA";
                Signal3Score.Foreground = new SolidColorBrush(Colors.DarkRed);

                Signal3Signal.Content = "No DATA";
                Signal3Signal.Foreground = new SolidColorBrush(Colors.DarkRed);

                Signal4Score.Content = "No DATA";
                Signal4Score.Foreground = new SolidColorBrush(Colors.DarkRed);

                Signal4Signal.Content = "No DATA";
                Signal4Signal.Foreground = new SolidColorBrush(Colors.DarkRed);
            }






        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri baseUri = new Uri("https://min-api.cryptocompare.com");


            Uri LocalPath = new Uri(baseUri, "/data/tradingsignals/intotheblock/latest");

            Uri SubQueryTest = new Uri(LocalPath, ("?fsym="+ ASSET.Text + "&api_key={7518522f704453f042b646acd7e367f8f060ad70b5d4f6fa924edfd684f7a4b6}"));

            this.AskDataTrading(SubQueryTest);
        }
    }
}
