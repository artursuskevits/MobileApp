using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace MobileApp
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Brauzer : ContentPage
    {
        List<string> lehed = new List<string> { "https://www.instagram.com/thousand.cursed.enemies/", "https://thousand-cursed-enemies.com/en", "https://genius.com/Rewwqq-thousand-cursed-enemies-lyrics", "https://www.invokergame.com/" };
        new List<string> nimitused = new List<string> { "Cursed Inst", "Cursed Merch", "Amazing Song", "Invoker Game" };
        Xamarin.Forms.Entry entry;
        Button backbtn, homebtn, openbtn, historybtn,favoritesbtn;
        Xamarin.Forms.Picker picker;
        WebView webview;
        string HomePage = "https://www.tthk.ee";
        string Lastpage = "https://www.tthk.ee";
        new List<string> lastpages = new List<string> { "0", "https://www.tthk.ee" };
        new List<string> history = new List<string> {  "https://www.tthk.ee" };
    public Brauzer()
        {
            this.BackgroundColor = Color.FromRgb(255, 255, 255);
            favoritesbtn = new Button()
            {
                WidthRequest = 200,
                HeightRequest = 50
            };
            favoritesbtn.Text = "Lemmik";
            openbtn = new Button()
            {
                WidthRequest = 200,
                HeightRequest = 50
            };
            openbtn.Text = "Open messanger";

            backbtn = new Button()
            {
                WidthRequest = 200,
                HeightRequest = 50
            };
            backbtn.Text = "Back";

            homebtn = new Button()
            {
                WidthRequest = 200,
                HeightRequest = 50
            };
            homebtn.Text = "Home";

            historybtn = new Button()
            {
                WidthRequest = 200,
                HeightRequest = 50
            };
            homebtn.Text = "History";

            entry = new Xamarin.Forms.Entry()
            {
                Placeholder = "Siseta uus veebileht",
                WidthRequest = 200,
               HeightRequest = 50
            };
            picker = new Xamarin.Forms.Picker
            {
                Title = "Veebileht",
                WidthRequest = 200,
                HeightRequest = 50
            };
            foreach (string leht in nimitused)
            {
                picker.Items.Add(leht);
            }
            webview = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://www.tthk.ee",
                },
                HeightRequest = 1000,
                WidthRequest = 400,
            };
            Grid actionStackLayout = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { homebtn, backbtn, openbtn,historybtn,favoritesbtn }
            };
            actionStackLayout.Children.Add(homebtn, 0, 0);
            actionStackLayout.Children.Add(backbtn, 1, 0);
            actionStackLayout.Children.Add(openbtn, 2, 0);
            actionStackLayout.Children.Add(historybtn, 3, 0);
            actionStackLayout.Children.Add(favoritesbtn, 4, 0);
            Content = new StackLayout { Children = { actionStackLayout, picker, entry, webview } };
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            entry.Completed += Entry_Completed;
            homebtn.Clicked += Homebtn_Clicked;
            backbtn.Clicked += Backbtn_Clicked;
            openbtn.Clicked += Openbtn_Clicked;
            historybtn.Clicked += Historybtn_Clicked;
            favoritesbtn.Clicked += Favoritesbtn_Clicked;
        }

        private async void Favoritesbtn_Clicked(object sender, EventArgs e)
        {
            string newfavorite=webview.Source.ToString();
            lehed.Add(newfavorite);
            string result = await DisplayPromptAsync("Vali uus nimi", "Ok");
            nimitused.Add(newfavorite);
        }

        private void Historybtn_Clicked(object sender, EventArgs e)
        {
            if (history.Count>2) {
                int historytange = history.Count;
                webview.Source = new UrlWebViewSource { Url = history[historytange - 2] };
                history.Remove(history[historytange - 1]);
            }
            else
            {
                DisplayAlert("Navigation", "See on viimane leht", "OK");
            }
        }

        private async void Openbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Call_friend());
        }

        private void Backbtn_Clicked(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = lastpages[0] };
            history.Add(lastpages[0]);
        }

        private void Homebtn_Clicked(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = HomePage };
            Lastpage = HomePage;
            history.Add(Lastpage);
            lastpages[0] = lastpages[1];
            lastpages[1] = Lastpage;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string url = "https://" + entry.Text;
            DisplayAlert("Navigation", $"Opening {url}", "OK");
            webview.Source = new UrlWebViewSource { Url = url };
            lehed.Add(url);
            nimitused.Add(url);
            Lastpage = url;
            history.Add(Lastpage);
            lastpages[0] = lastpages[1];
            lastpages[1] = Lastpage;
            picker.ItemsSource = nimitused; ;

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            webview.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
            Lastpage = lehed[picker.SelectedIndex];
            history.Add(Lastpage);
            lastpages[0] = lastpages[1];
            lastpages[1] = Lastpage;
        }
    } 
}