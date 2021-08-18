using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.Dao
{
    public class OderDetailsDAO
    {
        private BanXeDB db = null;
        public OderDetailsDAO()
        {
            db = new BanXeDB();
        }
        public bool Insert(OderDetail oderDetail)
        {
            try
            {
                db.OderDetails.Add(oderDetail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}