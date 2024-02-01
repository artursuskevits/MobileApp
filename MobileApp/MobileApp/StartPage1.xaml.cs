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
    public partial class StartPage1 : ContentPage
    {
        public StartPage1()
        {
            Button Entrybutton = new Button
            {
                Text = "Entry leht",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia
            };
            Button Timebutton = new Button
            {
                Text = "Time leht",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia
            };
            Button Boxbutton = new Button
            {
                Text = "Box leht",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            BackgroundColor = Color.FromRgb(32, 32, 255)
            };
            st.Children.Add(Entrybutton);
            st.Children.Add(Timebutton);
            st.Children.Add(Boxbutton);
            Content = st;
            Entrybutton.Clicked += Entrybutton_Clicked;
            Timebutton.Clicked += Timebutton_Clicked;
            Boxbutton.Clicked += Boxbutton_Clicked;
        }

        private async void Boxbutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Box_view());
        }

        private async void Timebutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimePage());
        }

        private async void Entrybutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}