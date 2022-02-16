using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour News_View.xaml
    /// </summary>
    public partial class News_View : UserControl
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        private async void AskDataNews(string URL)
        {
            newsData news = null;
            news = await News_DATA.GetNewsAsync(URL);


            List<string> titles = new List<string>();
            List<string> bodys = new List<string>();
            List<string> links = new List<string>();
            List<string> dates = new List<string>();

            foreach (var item in news.Data)
            {
                //Console.WriteLine(Histo_DATA.UnixTimeStampToDateTime(item.time) + " " + item.close);

                titles.Add(item.title);
                bodys.Add(item.body);
                links.Add(item.url);
                dates.Add(UnixTimeStampToDateTime(item.published_on).ToString());

            }

            string[] titlesArray = titles.ToArray();
            string[] bodysArray = bodys.ToArray();
            string[] linksArray = links.ToArray();
            string[] datesArray = dates.ToArray();

            title1.Content = titlesArray[0];
            title2.Content = titlesArray[1];
            title3.Content = titlesArray[2];


            body1.Content = bodysArray[0];
            body2.Content = bodysArray[1];
            body3.Content = bodysArray[2];


            link1.Content = linksArray[0];
            link2.Content = linksArray[1];
            link3.Content = linksArray[2];

            date1.Content = datesArray[0];
            date2.Content = datesArray[1];
            date3.Content = datesArray[2];



        }

        public News_View()
        {
            InitializeComponent();
            this.AskDataNews("https://min-api.cryptocompare.com/data/v2/news/?lang=EN");



        }
    }
}
