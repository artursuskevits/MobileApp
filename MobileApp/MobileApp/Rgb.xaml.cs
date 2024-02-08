using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rgb : ContentPage
    {
        Label redlbl, bluelbl, greenlbl;
        Slider redsld, bluesld, greensld;
        BoxView box;
        Button rbtn,rbtn2,rbtn3;
        Random rnd;

        public Rgb()
        {
            box = new BoxView
            { 
                
                WidthRequest = 200,
                HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            redlbl = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            greenlbl = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            bluelbl = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            bluesld = new Slider
            {
                Minimum = 0,
                Maximum = 256,
                Value = 3,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
            };

            greensld = new Slider
            {
                Minimum = 0,
                Maximum = 256,
                Value = 3,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
            };

            redsld = new Slider
            {
                Minimum = 0,
                Maximum = 256,
                Value = 3,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
            };
            rbtn = new Button
            {
                Text = "Set Random Color"
            };
            rbtn2 = new Button
            {
                Text = "Set Random Size"
            };
            rbtn3 = new Button
            {
                Text = "Set Default Size"
            };
            redsld.ValueChanged += OnSlideValueChanged;
            bluesld.ValueChanged += OnSlideValueChanged;
            greensld.ValueChanged += OnSlideValueChanged;
            rbtn.Clicked += Rbtn_Clicked;
            rbtn2.Clicked += Rbtn2_Clicked;
            rbtn3.Clicked += Rbtn3_Clicked;
            StackLayout stackLayout = new StackLayout
            {
                Children = { box, redsld, redlbl, greensld, greenlbl, bluesld, bluelbl,rbtn,rbtn2,rbtn3 },
                Margin = new Thickness(20)
            };

            Content = stackLayout;
            ScrollView sv = new ScrollView { Content = stackLayout };
            Content = sv;
        }

        private void Rbtn3_Clicked(object sender, EventArgs e)
        {
            box.WidthRequest = 200;
            box.HeightRequest = 400;
            box.CornerRadius = 1;
        }

        private void Rbtn2_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            int ar = rnd.Next(0, 255);
            int ag = rnd.Next(0, 255);
            int ab = rnd.Next(0, 255);
            box.WidthRequest = ar;
            box.HeightRequest = ag;
            box.CornerRadius = ab;
        }

        private void Rbtn_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            int ar = rnd.Next(0, 300);
            int ag = rnd.Next(0, 300);
            int ab = rnd.Next(0, 300);
            box.Color = Color.FromRgb(ar, ag, ab);
        }


        void OnSlideValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == redsld)
            {
                redlbl.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == greensld)
            {
                greenlbl.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            else if (sender == bluesld)
            {
                bluelbl.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }

            box.Color = Color.FromRgb((int)redsld.Value, (int)greensld.Value, (int)bluesld.Value);
        }
    }
}
