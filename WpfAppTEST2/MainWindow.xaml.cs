using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfAppTEST2.ViewModel;

namespace WpfAppTEST2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DataContext = new Home_ViewModel();
            InitializeComponent();
        }



        private void Histo_Chart_View_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Histo_Chart_ViewModel();
        }

        private void Social_View_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Social_ViewModel();

        }

        private void Trading_Signal_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Trading_Signal_ViewModel();
        }

        private void MarketCap_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new MarketCapDiff_ViewModel();
        }

        private void Indices_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new indicesList_ViewModel();
        }

        private void News_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new News_ViewModel();
        }

        private void Home_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Home_ViewModel();
        }
    }
}
