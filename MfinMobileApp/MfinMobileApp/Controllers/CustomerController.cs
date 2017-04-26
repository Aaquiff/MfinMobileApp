using MfinMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MfinMobileApp.Controllers
{
    class CustomerController
    {
        public ObservableCollection<Customer> Items { get; }


        public CustomerController()
        {

            Items = new ObservableCollection<Customer>(new[]
            {
                new Customer { customerId = "1", fullName= "Aaquiff", Address = "7,p[adfadfadfa"},
                new Customer { customerId = "2", fullName= "Rauf" , Address = "7,p[adfadfadfa"},
                new Customer { customerId = "3", fullName= "Mark" , Address = "7,p[adfadfadfa"},
                new Customer { customerId = "4", fullName= "Tom" , Address = "7,p[adfadfadfa"},
                new Customer { customerId = "5", fullName= "Steve" , Address = "7,p[adfadfadfa"}
            });
        }

        public ObservableCollection<Customer> GetCustomers()
        {
            return Items;
        }
    }
}