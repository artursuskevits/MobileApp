using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class Europa : ContentPage
    {
        public ObservableCollection<Country> countrys { get; set; }
        public ObservableCollection<Ruhm<string, Country>> Countryruhmades { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        Country selectedCountry;

        List<string> Allcountrys = new List<string> { };
        public Europa()
        {
            lisa = new Button { Text = "Lisa Riik" };
            kustuta = new Button { Text = "Kustuta Riik" };
            countrys = new ObservableCollection<Country>
                {
                new Country { Nimi = "Estonia", Pealinn = "Tallinn", Rahvaarv = 1373101, Flag="Estonia.png",FirstLetter="E"},
                new Country { Nimi = "Russia", Pealinn = "Moscow", Rahvaarv = 147182123, Flag="Russia.png",FirstLetter="R"},
                new Country { Nimi = "Ukraine", Pealinn = "Kiev", Rahvaarv = 33200000, Flag="Ukraine.png",FirstLetter="U"},
                new Country { Nimi = "Romania", Pealinn = "Bucharest", Rahvaarv = 19051562, Flag="Romania.png",FirstLetter="R"},
                };
            foreach (Country item in countrys)
            {
                Allcountrys.Add(item.Nimi);
            }
            var ruhmad = countrys.GroupBy(p => p.FirstLetter)
                         .Select(g => new Ruhm<string, Country>(g.Key, g));
            Countryruhmades = new ObservableCollection<Ruhm<string, Country>>(ruhmad);


            lbl_list = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Europa CRiigid",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Riigid:",
                Footer = DateTime.Now.ToString("T"),
                HasUnevenRows = true,
                ItemsSource = Countryruhmades,
                IsGroupingEnabled = true,
                GroupHeaderTemplate = new DataTemplate(() =>
                {

                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "FirstLetter");
                    tootja.TextColor = Color.Orange;
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { tootja }
                        }
                    };
                }),
                ItemTemplate = new DataTemplate(() =>
                {
                    Image img = new Image()
                    {
                        WidthRequest = 100,
                        HeightRequest = 100
                    };
                    img.SetBinding(Image.SourceProperty, "Flag");
                    Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimi");
                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Rahvaarv");



                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children = { img, nimetus, hind }
                        }
                    };
                })
            };

            list.ItemTapped += List_ItemTapped;
            lisa.Clicked += Lisa_Clicked;
            kustuta.Clicked += Kustuta_Clicked;
            this.Content = new StackLayout { Children = { lbl_list, list, lisa, kustuta } };

        }
        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Allcountrys.Add(selectedCountry.Nimi);
            countrys.Remove(selectedCountry);
            var ruhmad = countrys.GroupBy(p => p.FirstLetter)
                         .Select(g => new Ruhm<string, Country>(g.Key, g));
           Countryruhmades = new ObservableCollection<Ruhm<string, Country>>(ruhmad);
            list.ItemsSource = null;
            list.ItemsSource = Countryruhmades;
        }

        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            int X = 0;
            string Nimi = await DisplayPromptAsync("Vali uus Nimi ", "Uus Nimi ");
            string Pealinn = await DisplayPromptAsync("Vali uus Palinn", "Uus Palinn");
            string Rahvaarv = await DisplayPromptAsync("Vali uus Rahvaarv", "Uus Rahvaarv");
            if (Nimi != "" && Pealinn!= "" && Rahvaarv != "" && Nimi != null && Pealinn != null && Rahvaarv != null && Int32.TryParse(Rahvaarv, out int hindValue))
            {
                try
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    ImageSource vlad = ImageSource.FromFile(photo.FullPath);
                    var firstLetter = Nimi[0].ToString();
                    if (Allcountrys.Contains(Nimi))
                    {
                       
                    }
                    else
                    {
                        countrys.Add(new Country { Pealinn = Pealinn, Nimi = Nimi, Rahvaarv = Int32.Parse(Rahvaarv), Flag = vlad, FirstLetter = firstLetter });
                        var ruhmad = countrys.GroupBy(p => p.FirstLetter)
                                     .Select(g => new Ruhm<string, Country>(g.Key, g));
                        Countryruhmades = new ObservableCollection<Ruhm<string, Country>>(ruhmad);
                        list.ItemsSource = null;
                        list.ItemsSource = Countryruhmades;
                    }
                    
                }
                catch (Exception)
                {
                }

            }

        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            selectedCountry = e.Item as Country;
            if (selectedCountry != null)
            {
                await DisplayAlert("See on", $"{selectedCountry.Nimi} | {selectedCountry.Pealinn} rahvaarv on {selectedCountry.Rahvaarv} ","Ok");
            }
        }
    }
}