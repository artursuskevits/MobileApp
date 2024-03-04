using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Call_friend : ContentPage
    {
        TableView tableView;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
        EntryCell tel_nr_email,texte,textn,text;

        public Call_friend()
        {
            sc = new SwitchCell();
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("urod.jpg"),
                Text = "FotoNimetus",
                Detail = "Foto Kirjeldus"
            };
            tel_nr_email = new EntryCell()
            {
                Label = "Nimi",
                Placeholder = "Sisesta sõbraga nimi",
                Keyboard = Keyboard.Default,
            };
            textn = new EntryCell()
            {
                Label = "Sõnum",
                Placeholder = "Sisesta sõnum",
                Keyboard = Keyboard.Default,
            };
            texte = new EntryCell()
            {
                Label = "Sõnum",
                Placeholder = "Sisesta sõnum",
                Keyboard = Keyboard.Default,
            };
            fotosection = new TableSection();
            tableView = new TableView()
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed: ")
                    {
                        tel_nr_email
                    },
                    new TableSection("Kontaktiandmed: ")
                    {
                        new EntryCell
                        {
                            Label = "Telefon",
                            Placeholder= "Sisesta tel. number",
                            Keyboard=Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label = "Email",
                            Placeholder= "Sisesta email",
                            Keyboard=Keyboard.Email
                        },
                        sc
                    },
                    fotosection
                }
            };

            Button sms_btn = new Button { Text = "Saada SMS" };
            sms_btn.Clicked += Sms_btn_Clicked;

            Button call_btn = new Button { Text = "Helista" };
            call_btn.Clicked += Call_btn_Clicked;

            Button mail_btn = new Button { Text = "Kirjuta kiri" };
            mail_btn.Clicked += Mail_btn_Clicked;

            Grid actionStackLayout = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };
            actionStackLayout.Children.Add(call_btn, 0, 0);
            actionStackLayout.Children.Add(sms_btn, 1, 0);
            actionStackLayout.Children.Add(mail_btn, 2, 0);

            Content = new StackLayout { Children = { tableView, actionStackLayout } };
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(ic);
                sc.Text = "Näita veel";
            }
        }

        private void Sms_btn_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel_nr_email.Text, textn.Text);
            }
        }

        private void Call_btn_Clicked(object sender, EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel_nr_email.Text);
            }
        }

        private void Mail_btn_Clicked(object sender, EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(tel_nr_email.Text, "Tervitus!", text.Text);
            }
        }
    }
}
