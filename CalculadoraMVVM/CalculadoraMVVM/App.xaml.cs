﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculadoraMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new Views.Calculadora();
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
