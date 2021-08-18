using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.CustomModel
{
    [Serializable]
    public class CartItem
    {

        public Car Car { get; set; }
        public int Quantity { get; set; }
    }
}