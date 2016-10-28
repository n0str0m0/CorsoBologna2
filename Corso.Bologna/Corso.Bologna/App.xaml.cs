﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corso.Bologna.Views;
using Xamarin.Forms;

namespace Corso.Bologna
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainView();
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
