using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebLaiXe.Models.CustomModel;
using WebLaiXe.Models.Dao;

namespace WebLaiXe.Controllers
{
    public class CartController : Controller
    {
        private const string Cartsession = "Cartsession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Cartsession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ViewBag.total = TotalPrice();
            return View(list);
        }
        private double TotalPrice()
        {
            var cart = Session[Cartsession];
            var list = new List<CartItem>();
            double sum = 0;
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            foreach(var item in list) 
            {
                sum += (double)(item.Car.Price * item.Quantity);
            }
            return sum;
        }
        public ActionResult AddItem(int cartId , int quantity)
        {
                var car = new CartDAO().getDetailCart(cartId);
                var cart = Session[Cartsession];
                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    if (list.Exists(x => x.Car.ID == cartId))
                    {
                        foreach (var item in list)
                        {
                            if (item.Car.ID == cartId)
                            {
                                item.Quantity += quantity;
                            }
                        }
                    }
                    else
                    {
                        //tao moi doi tuong cartitem
                        var item = new CartItem();
                        item.Car = car;
                        item.Quantity = quantity;
                        list.Add(item);
                    }
                    Session[Cartsession] = list;
                }
                else
                {
                    //tao moi doi tuong cartitem
                    var item = new CartItem();
                    item.Car = car;
                    item.Quantity = quantity;
                    var list = new List<CartItem>();
                    list.Add(item);
                    //gan session
                    Session[Cartsession] = list;
                }
                return RedirectToAction("index");
        }
        public JsonResult DeleteAll()
        {
            Session[Cartsession] = null;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult PayMent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PayMent( string Name, int NumberPhone, string Address, string Email)
        {
            if(HttpContext.Application["ID"] == null)
            {
                return Redirect("/home/login");
            }
            else
            {
                var oder = new Oder();
                oder.CreatedDate = DateTime.Now;
                oder.CusName = Name;
                oder.CusPhoneNumber = NumberPhone;
                oder.CusEmail = Email;
                oder.CusAddress = Address;
                oder.CustomerID = int.Parse(HttpContext.Application["ID"].ToString());
                try
                {
                    var id = new OderDAO().Insert(oder);
                    var cart = (List<CartItem>)Session[Cartsession];
                    var detailDAO = new OderDetailsDAO();
                    foreach (var item in cart)
                    {
                        var oderDetails = new OderDetail();
                        oderDetails.OrderID = id;
                        oderDetails.CarID = item.Car.ID;
                        oderDetails.Price = (Double)item.Car.Price;
                        oderDetails.Quantity = item.Quantity;
                        detailDAO.Insert(oderDetails);
                    }
                }
                catch (Exception ex)
                {
                    return Redirect("/");
                    throw;
                }
                return Redirect("/cart/payment");
            }
        }
        public ActionResult Success()
        {
            return View();
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[Cartsession];
            sessionCart.RemoveAll(x=>x.Car.ID == id);
            Session[Cartsession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var JsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[Cartsession];
            foreach(var item in sessionCart)
            {
                var JsonItem = JsonCart.SingleOrDefault(x => x.Car.ID == item.Car.ID);
                if (JsonItem != null)
                {
                    item.Quantity = JsonItem.Quantity;
                }
            }
            Session[Cartsession] = sessionCart;
            return Json( new {
                status = true
            });
        }
    }
}