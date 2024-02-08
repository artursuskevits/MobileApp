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
    public partial class StartPAge2 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage> { new EntryPage(), new TimePage(), new Box_view() , new DateTimePage(), new SlideStepper(),new Rgb(),new lumemm()};
        List<string> texts = new List<string>() { "Ava entry leht", "Ava timer leht", "Ava Box View","DateTimePAge","SildeStepper", "Rgb","Lumememm" };
        StackLayout st;
        public StartPAge2()
        {
            st = new StackLayout
            {
                Orientation =StackOrientation.Vertical,
                BackgroundColor = Color.AliceBlue
            };
            for (int i=0; i <pages.Count;i++)
            {
                Button button = new Button
                {
                    Text = texts[i],
                    BackgroundColor=Color.FromHex("#52"),
                    TextColor=Color.Black,
                    TabIndex= i
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}