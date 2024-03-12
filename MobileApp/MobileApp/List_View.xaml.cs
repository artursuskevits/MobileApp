using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class List_View : ContentPage
    {
        public List<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;


        public List_View()
        {
            telefons = new List<Telefon>
                {
                new Telefon { Nimetus = "Samsung Galaxy S22 Ultra", Tootja = "Samsung", Hind = 1349 },
                new Telefon { Nimetus = "Xiaomi Mi 11 Lite 5G NE", Tootja = "Xiaomi", Hind = 399 },
                new Telefon { Nimetus = "Xiaomi Mi 11 Lite 5G", Tootja = "Xiaomi", Hind = 339 },
                new Telefon { Nimetus = "iPhone 13", Tootja = "Apple", Hind = 1179 }
                };
            lbl_list = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Telefonid loetelu",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            list = new ListView {
                HasUnevenRows = true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nimetus = new Label { FontSize = 20 };
                    nimetus.SetBinding(Label.TextProperty, "Nimetus");
                    Label tootja = new Label();
                    tootja.SetBinding(Label.TextProperty, "Tootja");
                    Label hind = new Label();
                    hind.SetBinding(Label.TextProperty, "Bind");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { nimetus, tootja, hind }
                        }
                    };
                })
            };
            list.ItemTapped += List_ItemTapped;
            this.Content = new StackLayout { Children = { lbl_list, list } };

        }

        private async void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Telefon selectedPhone = e.Item as Telefon;
            if (selectedPhone!=null)
            {
                await DisplayAlert("See on", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus} ","Ok");
            }
        }
    }
}