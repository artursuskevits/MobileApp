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
        Button  backbtn, homebtn,openbtn;
        Xamarin.Forms.Picker picker;
        WebView webview;
        string HomePage = "https://www.tthk.ee";
        string Lastpage = "https://www.tthk.ee";
        new List<string> lastpages = new List<string> { "0", "https://www.tthk.ee" };
        public Brauzer()
        {
            openbtn = new Button();
            openbtn.Text = "Open messanger";

            backbtn = new Button();
            backbtn.Text = "Back";

            homebtn = new Button();
            homebtn.Text = "Home";

            entry = new Xamarin.Forms.Entry();
            {
               
            };
            picker = new Xamarin.Forms.Picker
            {
                Title = "Veebileht"
            };
            foreach (string leht in nimitused)
            {
                picker.Items.Add(leht);
            }
            webview  = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://www.tthk.ee",
                },
                HeightRequest = 1000,
                WidthRequest = 100,
            };
            Content = new StackLayout { Children = { picker, entry,webview,backbtn,homebtn,openbtn} };
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            entry.Completed += Entry_Completed;
            homebtn.Clicked += Homebtn_Clicked;
            backbtn.Clicked += Backbtn_Clicked;
            openbtn.Clicked += Openbtn_Clicked;
        }

        private async void Openbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Call_friend()); 
        }

        private void Backbtn_Clicked(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = lastpages[0] };

        }

        private void Homebtn_Clicked(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = HomePage};
            Lastpage = HomePage;
            lastpages[0] = lastpages[1];
            lastpages[1] = Lastpage;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string url = entry.Text;
            DisplayAlert("Navigation", $"Opening {url}", "OK");
            webview.Source = new UrlWebViewSource { Url = url };
            lehed.Add(url);
            nimitused.Add(url);
            Lastpage = url;
            lastpages[0] = lastpages[1];
            lastpages[1] = Lastpage;
            picker.ItemsSource = nimitused; ;
            
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            webview.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
            Lastpage = lehed[picker.SelectedIndex];
            lastpages[0] = lastpages[1];
            lastpages[1] = Lastpage;
        }
    }
}