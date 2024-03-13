using System;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class List_View : ContentPage
    {
        public ObservableCollection<Telefon> telefons { get; set; }
        public ObservableCollection<Ruhm<string, Telefon>> telefonideruhmades { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        Telefon selectedPhone;
        public List_View()
        {
            lisa = new Button { Text = "Lisa felefon" };
            kustuta = new Button { Text = "Kustuta telefn" };
            telefons = new ObservableCollection<Telefon>
                {
                new Telefon { Nimetus = "Samsung Galaxy S22 Ultra", Tootja = "Samsung", Hind = 1349, Pilt="SamsungGalaxy.jpg"},
                new Telefon { Nimetus = "Xiaomi Mi 11 Lite 5G NE", Tootja = "Xiaomi", Hind = 399, Pilt="XiamaiMi11Lite5GNE.jpg" },
                new Telefon { Nimetus = "Xiaomi Mi 11 Lite 5G", Tootja = "Xiaomi", Hind = 339 , Pilt="XiaomiMi11Lite5G.jpg"},
                new Telefon { Nimetus = "iPhone 13", Tootja = "Apple", Hind = 1179 , Pilt = "Iphone13.jpg"}
                };
            var ruhmad = telefons.GroupBy(p => p.Tootja)
                         .Select(g => new Ruhm<string, Telefon>(g.Key, g));
            telefonideruhmades = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);
            lbl_list = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Telefonid loetelu",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView
            {
                SeparatorColor = Color.Orange,
                Header = "Telefonid rühmades",
                Footer = DateTime.Now.ToString("T"),
                HasUnevenRows = true,
                ItemsSource = telefonideruhmades,
                IsGroupingEnabled = true,
                //ItemsSource =telefons,
                GroupHeaderTemplate = new DataTemplate(() =>
                {
                  
                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Nimetus");
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
                    Image img = new Image() { WidthRequest =100,
                    HeightRequest=100};
                    img.SetBinding(Image.SourceProperty, "Pilt");
                    Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");
                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Hind");
                    


                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children = { img,nimetus, hind }
                        }
                    };
                })
            };

list.ItemTapped += List_ItemTapped;
            lisa.Clicked += Lisa_Clicked;
            kustuta.Clicked += Kustuta_Clicked;
            this.Content = new StackLayout { Children = { lbl_list, list,lisa,kustuta} };

        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            telefons.Remove(selectedPhone);
            var ruhmad = telefons.GroupBy(p => p.Tootja)
                         .Select(g => new Ruhm<string, Telefon>(g.Key, g));
            telefonideruhmades = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);
            list.ItemsSource = null;
            list.ItemsSource = telefonideruhmades;
        }

        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            int X = 0;
            string Tootja = await DisplayPromptAsync("Vali uus Tootja", "Uus Tootja");
            string Mudel = await DisplayPromptAsync("Vali uus Mudel", "Uus Mudel");
            string Hind= await DisplayPromptAsync("Vali uus Hind", "Uus Hind");
            if (Tootja!="" && Mudel != "" && Hind != "" && Tootja != null && Mudel != null && Hind != null && Int32.TryParse(Hind, out int hindValue) )
            {
                try
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    ImageSource vlad = ImageSource.FromFile(photo.FullPath);
                    telefons.Add(new Telefon { Nimetus = Mudel, Tootja = Tootja, Hind = Int32.Parse(Hind), Pilt = vlad });
                    var ruhmad = telefons.GroupBy(p => p.Tootja)
                                 .Select(g => new Ruhm<string, Telefon>(g.Key, g));
                    telefonideruhmades = new ObservableCollection<Ruhm<string, Telefon>>(ruhmad);
                    list.ItemsSource = null;
                    list.ItemsSource = telefonideruhmades;
                }
                catch (Exception)
                {
                }
                
            }
            
        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            selectedPhone= e.Item as Telefon;
            if (selectedPhone!=null)
            {
                await DisplayAlert("See on", $"{selectedPhone.Tootja} | {selectedPhone.Nimetus} - {selectedPhone.Hind} eurot","Ok");
            }
        }
    }
}