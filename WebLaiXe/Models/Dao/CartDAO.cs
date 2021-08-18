using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.Dao
{
    public class CartDAO
    {
        private BanXeDB db = null;
        public CartDAO()
        {
            db = new BanXeDB();
        }
        public Car getDetailCart(int id)
        {
            return db.Cars.Find(id);
        }
    }
}