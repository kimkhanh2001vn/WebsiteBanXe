using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.CustomModel
{
    public class CarDetails
    {
        public int ID { get; set; }
        public Car car { get; set; }
        public CarCategory carcate { get; set; }
        public string color { get; set; }
        public int Quantity { get; set; }
        public string Content { get; set; }
    }
}