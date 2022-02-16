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
    /// Logique d'interaction pour indicesList_View.xaml
    /// </summary>
    public partial class indicesList_View : UserControl
    {
        private async void AskDataIndices(string URL)
        {
            IndiceDATA indices = null;
            indices = await Indice_DATA.GetIndice_DATAAsync(URL);



        }

        public indicesList_View()
        {
            InitializeComponent();
            this.AskDataIndices("https://min-api.cryptocompare.com/data/index/list");
        }
    }
}
