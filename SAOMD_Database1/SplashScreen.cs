using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;


namespace SAOMD_Database1
{
    [Activity(Label = "SAOMD DB", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/icon")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Display Splash Screen for 5 Sec  
            Thread.Sleep(5000);
            //Start MainActivity
            StartActivity(typeof(MainActivity));
        }
    }
}