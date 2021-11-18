using FingerPrintSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FingerPrintSample
{
    public partial class App : Application
    {
        static Sqlhelper database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }


        public static Sqlhelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new Sqlhelper();
                }
                return database;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
