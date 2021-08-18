using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PagedList;
using PagedList.Mvc;
using WebLaiXe.Models;
using WebLaiXe.Models.CustomModel;
using WebLaiXe.Models.Dao;

namespace WebLaiXe.Controllers
{
    public class HomeController : Controller
    {
        private BanXeDB db = new BanXeDB();
        public ActionResult Index()
        {
            ViewBag.car = db.Cars.ToList();
            ViewBag.carcate = db.CarCategories.Where(x => x.Status == true).ToList();
            return View();
        }
        public ActionResult Product(int? page)
        { 
            int isize = 6;
            int iPageNum = (page ?? 1);
            var sanpham = db.Cars.Where(x => x.Status == true).ToList();
            // ViewBag.theochude = db.SACHes.Where(x => x.MaCD == iMaCD).ToList();
            return View(sanpham.ToPagedList(iPageNum, isize));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(int id)
        {
           
            var car = (from a in db.Cars
                           join b in db.CarCategories on a.ID equals b.ID
                           where a.ID == id
                           select new
                           {
                               a.Name,
                               a.Content,
                               a.Price,
                               a.ID,
                               b.NameCate,
                               a.Images,
                               b.Status
                           }).ToList();

            var idcar = car[0].ID;
            var carDetailList = db.CarDetails.Where(x => x.IdCar == id).ToList();
            int idcarDetail = carDetailList[0].ID;
            ViewBag.Specification = db.Specifications.Where(x => x.IDCarDetail == idcarDetail).ToList();
            ViewBag.SpecificationDetail = db.Specifications.Where(x => x.IDCarDetail == idcarDetail).Join(db.SpecificationDetails, Specification => Specification.ID,SpecificationDetail=>SpecificationDetail.IdSpecification , (Specification, SpecificationDetail) => new
            {
                Specification.ID,
                Specification.SpecificationName,
                SpecificationDetail.Content,
                SpecificationDetail.Name,
                SpecificationDetail.IdSpecification
            }).ToList();

            ViewBag.car = car;
            return View();
        }
        public ActionResult Document()
        {
            ViewBag.document = db.Documents.ToList();
            ViewBag.docDetail = db.DocDetails.Where(x => x.Status == true).Join(db.Documents, DocDetail => DocDetail.DocID, Document => Document.ID, (DocDetail, Document) => new
            {
                DocDetail.Name,
                Document.NameDoc,
                DocDetail.Content,
                Document.ContentDoc,
                DocDetail.DocID
            }).ToList();
            return View();
        }
        
        //public JsonResult PublishComment(CommentInfo modal)
        //{
            
        //    JsonResult result = new JsonResult();
        //    try
        //    {
        //        var com = new ComDAO();
        //        var comment = new Comment();
        //        comment.Customer.ID = (int)HttpContext.Application["ID"];
        //        comment.Car.ID = modal.car.ID;
        //        comment.CreateDate = DateTime.Now;
        //        comment.Content = modal.content;
        //        var res = com.Insert(comment);
        //        result.Data = new { Succes = res };
        //    }
        //    catch(Exception e)
        //    {
        //        result.Data = new { Succes = false, Message = e.Message };
        //    }
        //    return result;
        //}
        public ActionResult Search(string searchString)
        {
            IQueryable<Car> Result = db.Cars;
            if (!string.IsNullOrEmpty(searchString))
            {
                Result = Result.Where(x => x.Name.Contains(searchString)).OrderByDescending(x => x.CreateDate);
            }
            return View(Result);
        }
        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            return Redirect("/");
        }
        public ActionResult SendMail()
        {
            string name = Request.Form["name"].ToString();
            string email = Request.Form["email"].ToString();
            string numberphone = Request.Form["number"].ToString();
            string inputMessage = Request.Form["messeger"].ToString();
            string from = "ngokhanh858@gmail.com";
            //Replace this with your own correct Gmail Address
            //thanh.tran @viet-tradeplus.com.vn
            string to = "thaim73@gmail.com";
            //thanh.tran @viet-tradeplus.com.vn
            //Replace this with the Email Address
            //to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from, "ngo kim khanh", System.Text.Encoding.UTF8);
            mail.Subject = "Request from Clients";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = inputMessage;

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            //587  port google mail
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            //Add the Creddentials- use your own email id and password
            System.Net.NetworkCredential nt =
            new System.Net.NetworkCredential(from, "206223432");

            client.Port = 587; // Gmail works on this port
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            client.UseDefaultCredentials = false;
            client.Credentials = nt;
            client.Send(mail);
            return View("Contact");
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string username,string email,string numberphone, string address,string name,string password,string passwordAgain)
        {
            try
            {
                var val = db.Customers.Where(x => x.UserName == username);
                var emailtes = db.Customers.Where(x => x.Email == email);

                if (val.Count() > 0)
                {
                    ViewBag.err1 = "Tài Khoản đã tồn tại";
                }
                else if (emailtes.Count() > 0)
                {
                    ViewBag.err3 = "Email Đã tồn tại";
                }
                else
                {
                    var customer = new Customer();
                    customer.UserName = username;
                    customer.Email = email;
                    customer.NumberPhone = int.Parse(numberphone);
                    customer.Address = address;
                    customer.Name = name;

                    if (password.Equals(passwordAgain))
                    {
                        customer.Password = password;
                        ViewBag.success = "Tạo Tài Khoản Thành Công";
                        db.Customers.Add(customer);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.err = "Mật Khẩu Không trùng lập";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View("Registration");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email , string pass)
        {
            
            CustomerInfo customer = db.Customers.Where(x => x.Email == Email && x.Password == pass).Select(x => new CustomerInfo
            {
                CustomerID = x.ID,
                UserName = x.UserName,
                password = x.Password,
                Email = x.Email,
                Name = x.Name,
                Address = x.Address
            }).FirstOrDefault();
            var check = db.Customers.Where(x => x.Email == Email && x.Password == pass).ToList();
            if (customer != null)
            {
                HttpContext.Application["ID"] = check[0].ID.ToString();
                Session["TaiKhoan"] = customer;
                Response.Redirect("/Home/product");
            }
            ViewBag.Thongbao = "Bạn đã sai mật khẩu hoặc tài khoản";
            Session["comments"] = customer;
            
            return View();
        }
    }
}