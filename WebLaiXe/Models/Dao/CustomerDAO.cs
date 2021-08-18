using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.Dao
{
    public class CustomerDAO
    {
        private BanXeDB db = null;
        public CustomerDAO()
        {
            db = new BanXeDB();
        }
        public Customer getDetailCus(int id)
        {
            return db.Customers.Find(id);
        }
    }
}