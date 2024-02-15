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
    public partial class Frame_Page : ContentPage
    {
        Grid grid;
        Random rnd = new Random();
        Frame fr;
        Label lbl;
        TapGestureRecognizer tap;
        Image image;
        Switch sw;
        public Frame_Page()
        {
            grid = new Grid
            {
                BackgroundColor = Color.LightBlue,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 1;

            for (int i = 0; i < 4; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    grid.Children.Add(
                        fr = new Frame { BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)) ,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand
                        }, i, ii
                        );

                    fr.GestureRecognizers.Add(tap);

                }
            }
            lbl = new Label
            {
                Text="ZXCZXCZXCZXCZXCZXCZXCZXC",FontSize=Device.GetNamedSize(NamedSize.Subtitle,typeof(Label))
            };
            grid.Children.Add(lbl,0,5);
            Grid.SetColumnSpan(lbl,4);
            image = new Image { Source ="urod.jpg"};
            sw = new Switch
            {
                IsToggled = false
            };
            sw.Toggled += Sw_Toggled;
            grid.Children.Add(sw, 0, 6);
            grid.Children.Add(image, 1, 6);
            Content = grid;
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {

                 image.Source = "urod.jpg";
            }
            else
            {
                image.Source="neutod.jpg" ;
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Frame fr = (Frame)sender;
            int r = Grid.GetRow(fr); int c = Grid.GetColumn(fr);
            r=r + 1;
            c = c + 1;
            lbl.Text = "Riida: " + r.ToString() + "Veerg: " + c.ToString();
            
        }
    }
}