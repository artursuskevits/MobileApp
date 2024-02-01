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
    public partial class Box_view : ContentPage
    {
        Label lbl;
        BoxView box;
        public Box_view()
        {
            int r = 0, g = 0, b = 0;
            lbl = new Label { Text = "Rgb is 0.0.0", TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center ,FontSize= 24};
            box = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                CornerRadius = 10,
                WidthRequest = 200,
                HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout { Children = { lbl,box } };
            Content = st;
        }
        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            int ar = rnd.Next(0, 255);
            int ag = rnd.Next(0, 255);
            int ab = rnd.Next(0, 255);
            box.Color = Color.FromRgb(ar, ag, ab);
            lbl.Text = "Rgb is "+ar+"."+ag+"."+ab;
        }
    }
}