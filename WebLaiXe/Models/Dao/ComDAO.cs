using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models.Dao
{
    public class ComDAO
    {
        private BanXeDB db = null;
        public ComDAO()
        {
            db = new BanXeDB();
        }
    }
}