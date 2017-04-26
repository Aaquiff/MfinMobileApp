using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MfinMobileApp.Model
{
    public class Customer
    {
        public string customerId { get; set; }
        public string fullName { get; set; }
        public int NIC { get; set; }
        public string Address { get; set; }
        public string mobileNumber { get; set; }
        public string homeTelephone { get; set; }
        public string officeTelephone { get; set; }
    }
}
