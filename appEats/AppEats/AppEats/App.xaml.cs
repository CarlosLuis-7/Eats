﻿using System;


namespace AppEats
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Views;
    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            InitializeComponent();

           this.MainPage = new NavigationPage  (new LoginPage());
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        #endregion
    }
}
