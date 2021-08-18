using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.Dao
{
    public class OderDAO
    {
        private BanXeDB db = null;
        public OderDAO()
        {
            db = new BanXeDB();
        }
        public int Insert(Oder oder)
        {
            db.Oders.Add(oder);
            db.SaveChanges();
            return oder.ID;
        }
    }
}