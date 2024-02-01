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
    public partial class EntryPage : ContentPage
    {
        Label lbl;
        Editor editor;
        public EntryPage()
        {
            Button Kustutabutton = new Button
            {
                Text = "Kustuta",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia
            };
            Button Clearlbl = new Button
            {
                Text = "Clear Label",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            lbl = new Label { Text = "Minge tekst", BackgroundColor = Color.LightPink };
            editor = new Editor
            {
                Placeholder = "Sisseta siia tekst.....",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia,
                HorizontalOptions=LayoutOptions.Center
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromRgb(32, 32, 255),
                Children = {lbl,Kustutabutton,editor,Clearlbl},
                VerticalOptions =LayoutOptions.Center
            };
            Content = st;
            Kustutabutton.Clicked += Kustutabutton_Clicked;
            editor.TextChanged += Editor_TextChanged;
            Clearlbl.Clicked += Clearlbl_Clicked;
        }

        private void Clearlbl_Clicked(object sender, EventArgs e)
        {
            lbl.Text = "";
            editor.Text = "";
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbl.Text = editor.Text;
        }

        private async void Kustutabutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}