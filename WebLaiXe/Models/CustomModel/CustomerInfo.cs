using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models
{
    public class CustomerInfo
    {
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberPhone { get; set; }
    }
}