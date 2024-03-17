using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp
{   
    public class Country
    {
        public string Nimi { get; set; }
        public string Pealinn { get; set; }

        public string FirstLetter { get; set; }
        public int Rahvaarv { get; set; }


        public ImageSource Flag { get; set; }
    }
}
