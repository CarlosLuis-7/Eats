using System;
using System.Collections.Generic;
using System.Text;


namespace AppEats.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using System.ComponentModel;

    public class LoginViewModel: BaseViewModel
    {

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnable;
        #endregion

        #region Property
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get; set;
        }

        // limpiar las cajas de texto
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }

        #endregion

        #region Construction
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnable = true;

            // quemo datos de manera temporal
            this.email = "carlos@gmail.com";
            this.password = "1234";
            
        }

        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

       

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "you must enter an email",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                 "Error",
                 "you must enter an password",
                 "Aceptar");
                return;
            }

            this.IsRemembered = true;
            this.IsEnable = false;

            if (this.Email != "carlos@gmail.com" || this.Password != "1234")
            {
                this.IsRemembered = false;
                this.IsEnable = true;

                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Email or password incorrect",
                   "Aceptar");
                this.Password = string.Empty;
                return;

            }


            this.IsRemembered = false;
            this.IsEnable = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands= new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }


        #endregion
    }
}
