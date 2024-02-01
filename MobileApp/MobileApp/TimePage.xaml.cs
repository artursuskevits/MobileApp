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
    public partial class TimePage : ContentPage
    {

        public TimePage()
        {
            InitializeComponent();
        }

      
        private void Time_Run_Clicked(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
            }
            else
            {
                flag = true;
                NaitaAeg();
            }
        }
        bool flag = false;
        private async void NaitaAeg()
        {
            while(flag)
            {
                Time_run.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            List<string> colors = new List<string>
                {
                    "Green",
                    "Red",
                    "Blue",
                    "Yellow",
                    "Brown",
                    "Pink"
            };

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, colors.Count);
            string randomColorName = colors[randomIndex];

            Color randomColor = ColorFromName(randomColorName);
            lbl.TextColor = randomColor;


        }
        private Color ColorFromName(string colorName)
        {
            switch (colorName)
            {
                case "Green":
                    return Color.Green;
                case "Red":
                    return Color.Red;
                case "Blue":
                    return Color.Blue;
                case "Yellow":
                    return Color.Yellow;
                case "Brown":
                    return Color.Brown;
                case "Pink":
                    return Color.Pink;
                default:
                    return Color.Default; // or any other default color
            }
        }

    }
}