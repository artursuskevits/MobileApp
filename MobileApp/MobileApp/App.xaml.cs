﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class App : Application
    {
        public App()
        {

            MainPage = new NavigationPage(new StartPAge2());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
