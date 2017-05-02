using MfinMobileApp.Controllers;
using MfinMobileApp.Interfaces;
using MfinMobileApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MfinMobileApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDetail : ContentPage
    {
        Customer customer;
        public CustomerDetail(Customer cus)
        {
            this.customer = cus ;
            
            InitializeComponent();
            BindingContext = new CustomerDetailViewModel(cus);
            
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            DependencyService.Get<IPhoneCall>().MakeQuickCall(customer.phone);
        }
    }

    class CustomerDetailViewModel : INotifyPropertyChanged
    {

        public CustomerDetailViewModel(Customer cus)
        {
            this.Customer = cus;         
            
        }
        Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
