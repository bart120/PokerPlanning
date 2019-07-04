﻿using PokerPlanning.Services;
using PokerPlanning.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PokerPlanning
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<ISettingsStore, SettingsStore>();
            DependencyService.Register<IPokerStore, PokerStore>();
            MainPage = new MainPage();
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
