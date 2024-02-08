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
    public partial class lumemm : ContentPage
    {
        
            Label lbl;
        BoxView boxr1, boxr2, boxdef;
        Button hide, show;
        public lumemm()
            {
                int r = 0, g = 0, b = 0;
                lbl = new Label { Text = "Rgb is 0.0.0", TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, FontSize = 24 };
            boxdef = new BoxView
            {
                CornerRadius = 1,
                WidthRequest = 70,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Gray
            };
            boxr1 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };
            boxr2 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };
            hide = new Button
            {
                
                Text = "Hide snowman"
            };
            show = new Button
            {
                
                Text = "Show snowman"
            };
            show.Clicked += Show_Clicked;
            hide.Clicked += Hide_Clicked;
            TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap_Tapped;
                boxr1.GestureRecognizers.Add(tap);
            AbsoluteLayout abs = new AbsoluteLayout 
            {
                Children = { boxr1, boxr2, boxdef,hide,show }
            };
            AbsoluteLayout.SetLayoutBounds(boxdef, new Rectangle(0.4, 0.13, 300, 200));
            AbsoluteLayout.SetLayoutFlags(boxdef, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(boxr1, new Rectangle(0.4, 0.29, 300, 200));
            AbsoluteLayout.SetLayoutFlags(boxr1, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(boxr2, new Rectangle(0.4, 0.59, 300, 200));
            AbsoluteLayout.SetLayoutFlags(boxr2, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(hide, new Rectangle(0.1, 0.9, 300, 200));
            AbsoluteLayout.SetLayoutFlags(hide, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(show, new Rectangle(0.2, 0.9, 300, 200));
            AbsoluteLayout.SetLayoutFlags(show, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
            this.BackgroundColor = Color.Blue;
        }

        private void Hide_Clicked(object sender, EventArgs e)
        {
            if (boxr1.IsVisible==true)
            {
                boxr1.IsVisible = false;
                    boxr2.IsVisible = false;
                boxdef.IsVisible = false;
            }
            else
            {

            }
        }

        private void Show_Clicked(object sender, EventArgs e)
        {

            if (boxr1.IsVisible == false)
            {
                boxr1.IsVisible = true;
                boxr2.IsVisible = true;
                boxdef.IsVisible = true;
            }
            else
            {

            }
        }

        Random rnd;
            private void Tap_Tapped(object sender, EventArgs e)
            {
                rnd = new Random();
                int ar = rnd.Next(0, 255);
                int ag = rnd.Next(0, 255);
                int ab = rnd.Next(0, 255);
                boxr1.Color = Color.FromRgb(ar, ag, ab);
                lbl.Text = "Rgb is " + ar + "." + ag + "." + ab;
            }
        }
}