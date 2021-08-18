using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaiXe.Models;

namespace WebLaiXe.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private BanXeDB db = new BanXeDB();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.countoder = OderCount();
            ViewBag.cuscount = CusCount();
            ViewBag.percent = SumOder();
            return View();
        }
        public int OderCount()
        {
            return db.Oders.Count();
        }
        public int CusCount()
        {
            return db.Customers.Count();
        }
        public double SumOder()
        {
            var dt = db.OderDetails.Sum(x => x.Price);
            return (double)(dt);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["Users"] = null;
            return Redirect("/admin/home/login");
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            UserInfo users = db.Users.Where(x => x.UserName == username && x.PassWord == password).Select(x => new UserInfo
            {
                UserID = x.ID,
                UserName = x.UserName,
                PassWord = x.PassWord,
                DisplayName = x.DisplayName
            }).FirstOrDefault();
            Session["Users"] = users;
            if (Session["Users"] != null)
            {
                Response.Redirect("/Admin/Home/Index");
            }
            ViewBag.error = "Bạn Đăng Nhập Sai Tài Khoản Hoặc Mật Khẩu";
            return View();
         }
    }
}