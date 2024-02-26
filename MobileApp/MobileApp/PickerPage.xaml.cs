using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        int rcnt= 0;
        int lcnt = 0;
        string exurl = "";
        string lastmod = "";
        Picker picker;
        WebView webView;
        Frame frame;
        string[] lehed = new string[4] { "https://www.instagram.com/thousand.cursed.enemies/", "https://thousand-cursed-enemies.com/en", "https://genius.com/Rewwqq-thousand-cursed-enemies-lyrics", "https://www.invokergame.com/" };
        string[] nimitused = new string[4] {  "Cursed Inst", "Cursed Merch", "Amazing Song","Invoker Game" };
        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Veebileht"
            };

            foreach (string leht in nimitused)
            {
                picker.Items.Add(leht);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://moodle.edu.ee/course/view.php?id=37973",
                },
                HeightRequest = 1000,
                WidthRequest=100,
            };
            frame = new Frame
            {
                BackgroundColor = Color.Black
            };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer
            {
                Direction=SwipeDirection.Right
            };
            SwipeGestureRecognizer swipe2 = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Left
            };

            swipe.Swiped += Swipe_Swiped;
            swipe2.Swiped += Swipe2_Swiped;
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
           
            Content = new StackLayout { Children = { picker, webView,frame } };

            frame.GestureRecognizers.Add(swipe);
            frame.GestureRecognizers.Add(swipe2);
        }

        private void Swipe2_Swiped(object sender, SwipedEventArgs e)
        {
            if (picker.SelectedIndex >= 0 && picker.SelectedIndex < lehed.Length)

            {
                if (exurl == lehed[picker.SelectedIndex]&&lastmod =="left")
                {
                    lcnt++;
                }
                else
                {
                    lcnt = 1;
                }

                int newIndex = picker.SelectedIndex  - lcnt;
                if (newIndex <lehed.Length)
                {
                    webView.Source = new UrlWebViewSource { Url = lehed[newIndex] };
                }
                else
                {
                    webView.Source = new UrlWebViewSource { Url = "https://www.invokergame.com/" };
                }

                exurl = lehed[picker.SelectedIndex];
                lastmod = "left";
            }
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            if (picker.SelectedIndex >= 0 && picker.SelectedIndex < lehed.Length)

            {
                if (exurl == lehed[picker.SelectedIndex] && lastmod == "right")
                {
                    rcnt++;
                }
                else
                {
                    rcnt = 1;
                }

                int newIndex = picker.SelectedIndex - rcnt;
                if (newIndex >= 0 )
                {
                    webView.Source = new UrlWebViewSource { Url = lehed[newIndex] };
                }
                else
                {
                    webView.Source = new UrlWebViewSource { Url = "https://www.instagram.com/thousand.cursed.enemies/" };
                }

                exurl = lehed[picker.SelectedIndex];
                lastmod = "right";
            }
        }


        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
        }

    }
}
