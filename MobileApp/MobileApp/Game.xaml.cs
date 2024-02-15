using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        List<Label> tapped = new List<Label>();
        int counter=0;
        Grid grid;
        Image image;
        Label label;
        Button btnbot, btnonline;
        List<Label> X1 = new List<Label>();
        List<Label> X2 = new List<Label>();
        List<Label> X3 = new List<Label>();
        List<Label> Y1 = new List<Label>();
        List<Label> Y2 = new List<Label>();
        List<Label> Y3 = new List<Label>();
        public Game()
        {
            grid = new Grid
            {
                BackgroundColor = Color.LightBlue,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.NumberOfTapsRequired = 1;
            tap.Tapped += Tap_Tapped1;
            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    grid.Children.Add(
                        label = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Text = "emptyyyyyyyyyyyyyyyyyyy",
                            BackgroundColor = Color.White
                        }, i, ii
                        );
                    label.GestureRecognizers.Add(tap);
                }
            }
            
            btnbot = new Button
            {
                Text= "Play vs bot" 
            };
            btnonline = new Button
            {
                Text = "Play vs player"
            };
            grid.Children.Add(btnonline, 0, 4);
            grid.Children.Add(btnbot, 1, 4);
            Content = grid;
        }

        private void Tap_Tapped1(object sender, EventArgs e)
        {
            
            Label fr = (Label)sender;
            int r = Grid.GetRow(fr); int c = Grid.GetColumn(fr);
            if (counter % 2==0)
            {
                if (Grid.GetRow(fr) == r && Grid.GetColumn(fr) == c && fr.Text!="X" && fr.Text != "0")
                {
                    fr.Text = "X";
                    fr.FontSize = 34;
                    counter++;
                    tapped.Add(fr);
                    
                }
            }
            else
            {
                if (Grid.GetRow(fr) == r && Grid.GetColumn(fr) == c && fr.Text != "X" && fr.Text != "0")
                {
                    fr.Text = "0";
                    fr.FontSize = 34;
                    counter++;
                    tapped.Add(fr);
                }
            }
            int i = 0;

            X1.Clear();
            X2.Clear();
            X3.Clear();
            Y1.Clear();
            Y2.Clear();
            Y3.Clear();
            foreach (Label item in tapped)
            {
                if (Grid.GetRow(fr) == 0)
                {
                    X1.Add(fr);
                    btnonline.Text = X1.Count.ToString();
                    if (X1.Count==3)
                    {
                        int cnt = 0;
                        int cnt2 = 0;
                        foreach (Label item1 in X1)
                        {
                            if (item1.Text=="X")
                            {
                                cnt += 1;
                            }
                            else
                            {
                                cnt2+=1;
                            }
                            if (cnt==3)
                            {
                                btnonline.Text = "X Win"+ X1.Count.ToString(); 
                            }
                            else if (cnt2==3)
                            {
                                btnonline.Text = "0 Win"+X1.Count.ToString(); ;
                            }
                            else
                            {
                                    
                            }
                        }
                    }
                }
                else if (Grid.GetRow(fr) == 1)
                {
                    X2.Add(fr);
                    if (X2.Count == 3)
                    {
                        int cnt = 0;
                        int cnt2 = 0;
                        foreach (Label item1 in X2)
                        {
                            if (item1.Text == "X")
                            {
                                cnt += 1;
                            }
                            else
                            {
                                cnt2 += 1;
                            }
                            if (cnt == 3)
                            {
                                btnonline.Text = "X Win";
                            }
                            else if (cnt2 == 3)
                            {
                                btnonline.Text = "0 Win";
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else if (Grid.GetRow(fr) == 2)
                {
                    X3.Add(fr);
                    if (X3.Count == 3)
                    {
                        int cnt = 0;
                        int cnt2 = 0;
                        foreach (Label item1 in X3)
                        {
                            if (item1.Text == "X")
                            {
                                cnt += 1;
                            }
                            else
                            {
                                cnt2 += 1;
                            }
                            if (cnt == 3)
                            {
                                btnonline.Text = "X Win";
                            }
                            else if (cnt2 == 3)
                            {
                                btnonline.Text = "0 Win";
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else if (Grid.GetColumn(fr) == 0)
                {
                    Y1.Add(fr);
                    if (Y1.Count == 3)
                    {
                        int cnt = 0;
                        int cnt2 = 0;
                        foreach (Label item1 in Y1)
                        {
                            if (item1.Text == "X")
                            {
                                cnt += 1;
                            }
                            else
                            {
                                cnt2 += 1;
                            }
                            if (cnt == 3)
                            {
                                btnonline.Text = "X Win";
                            }
                            else if (cnt2 == 3)
                            {
                                btnonline.Text = "0 Win";
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else if (Grid.GetColumn(fr) == 1)
                {
                    Y2.Add(fr);
                    if (Y2.Count == 3)
                    {
                        int cnt = 0;
                        int cnt2 = 0;
                        foreach (Label item1 in Y2)
                        {
                            if (item1.Text == "X")
                            {
                                cnt += 1;
                            }
                            else
                            {
                                cnt2 += 1;
                            }
                            if (cnt == 3)
                            {
                                btnonline.Text = "X Win";
                            }
                            else if (cnt2 == 3)
                            {
                                btnonline.Text = "0 Win";
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else if (Grid.GetColumn(fr) == 2)
                {
                    Y3.Add(fr);
                    if (Y3.Count == 3)
                    {
                        int cnt = 0;
                        int cnt2 = 0;
                        foreach (Label item1 in Y3)
                        {
                            if (item1.Text == "X")
                            {
                                cnt += 1;
                            }
                            else
                            {
                                cnt2 += 1;
                            }
                            if (cnt == 3)
                            {
                                btnonline.Text = "X Win";
                            }
                            else if (cnt2 == 3)
                            {
                                btnonline.Text = "0 Win";
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else if(true)
                {

                }
            }
        }

        
    }
}