using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Call_friend : ContentPage
    {
        Xamarin.Forms.Entry tel_nr_email,text;

        public Call_friend()
        {
            tel_nr_email = new Xamarin.Forms.Entry { Placeholder = "Kirjuta siia telefoni number" };
            text = new Xamarin.Forms.Entry { Placeholder = "Kirjuta tekst siia" };

            Button sms_btn = new Button { Text = "Saada SMS"};
            sms_btn.Clicked += Sms_btn_Clicked;

            Button call_btn = new Button { Text = "Helista" };
            call_btn.Clicked += Call_btn_Clicked;

            Button mail_btn = new Button { Text = "Kirjuta kiri" };
            mail_btn.Clicked += Mail_btn_Clicked;

            Grid actionStackLayout = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { call_btn, sms_btn, mail_btn},
                
            };
            actionStackLayout.Children.Add(call_btn, 0, 0);
            actionStackLayout.Children.Add(sms_btn, 1, 0);
            actionStackLayout.Children.Add(mail_btn, 2, 0);
            Content = new StackLayout { Children = {tel_nr_email,text, actionStackLayout } };





        }
        private void Sms_btn_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel_nr_email.Text, text.Text); }
        }

        private void Call_btn_Clicked(object sender, EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall) {
                call.MakePhoneCall(tel_nr_email.Text); }
        }

        private void Mail_btn_Clicked(object sender, EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail){
                mail.SendEmail(tel_nr_email.Text, "Tervitus!", text.Text); }
        }
    }
}