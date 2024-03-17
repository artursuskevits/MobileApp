using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class Europa : ContentPage
    {
        public ObservableCollection<Country> Country { get; set; }
        public ObservableCollection<Ruhm<string, Country>> Countryruhmades { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        Country selectedCountry;
        public Europa()
        {
            InitializeComponent();
        }
    }
}