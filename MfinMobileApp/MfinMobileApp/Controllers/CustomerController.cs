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
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MfinMobileApp.Controllers
{
    class CustomerController
    {

        HttpClient client;
        public CustomerController()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;

        }

        public async Task<List<Customer>> GetCustomersRest()
        {
            try
            {
                var uri = new Uri("http://limitless-earth-71693.herokuapp.com/customers");
                string response = await client.GetStringAsync(uri);
                var postsarray = JsonConvert.DeserializeObject<List<Customer>>(response);
                return postsarray;
            }
            catch (Exception)
            {}
            return null;
        }


        public async Task<List<Customer>> GetCustomerRest(string id)
        {
            try
            {
                var uri = new Uri("http://limitless-earth-71693.herokuapp.com/customers/"+id);
                string response = await client.GetStringAsync(uri);
                var postsarray = JsonConvert.DeserializeObject<List<Customer>>(response);
                return postsarray;
            }
            catch (Exception)
            { }
            return null;
        }
    }
}