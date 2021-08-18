using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.CustomModel
{
    public class CommentInfo
    {
        public Customer Customer { get; set; }
        public Car car { get; set; }
        public DateTime CreateDate { get; set; }
        public string content { get; set; }
    }
}