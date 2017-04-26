using MfinMobileApp.Controllers;
using MfinMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MfinMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {

            //App.Navigation.PushAsync(new CustomerList());
            try
            {
                bool res = LoginController.Login("Aaquiff", "*******");
                if(res)
                    App.Current.MainPage = new NavigationPage(new Views.CustomerList());
                else
                    DisplayAlert("Invalid Login","Username or password is incorrect","OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR",ex.Message,"Cancel");
            }
        }

        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
