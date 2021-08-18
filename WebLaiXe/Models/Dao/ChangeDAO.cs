using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.Dao
{
    public class ChangeDAO
    {
        private BanXeDB db = new BanXeDB();
        public bool CartStatus(int id)
        {
            Car car = db.Cars.Find(id);
            car.Status = !car.Status;
            db.SaveChanges();
            return (bool)car.Status;
        }
    }
}