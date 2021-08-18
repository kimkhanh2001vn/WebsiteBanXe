using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebLaiXe;
using WebLaiXe.Models.Dao;

namespace WebLaiXe.Areas.Admin.Controllers
{
    public class CarsController : BaseController
    {
        private BanXeDB db = new BanXeDB();
        private string pic;

        // GET: Admin/Cars
        public ActionResult Index(int? page)
        {
            int isize = 6;
            int iPageNum = (page ?? 1);
            var cars = db.Cars.Include(x => x.CarCategory).ToList();
            return View(cars.ToPagedList(iPageNum, isize));
            //var cars = db.Cars.Include(c => c.CarCategory);
            //return View(cars.ToList());
        }

        // GET: Admin/Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Admin/Cars/Create
        public ActionResult Create()
        {
            ViewBag.IdCategory = new SelectList(db.CarCategories, "ID", "NameCate");
            return View();
        }

        // POST: Admin/Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Content,IdCategory,Place,Images,Brand,Status,Price,CreateDate")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategory = new SelectList(db.CarCategories, "ID", "NameCate", car.IdCategory);
            return View(car);
        }

        // GET: Admin/Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategory = new SelectList(db.CarCategories, "ID", "NameCate", car.IdCategory);
            return View(car);
        }

        // POST: Admin/Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Content,IdCategory,Place,Images,Brand,Status,Price,CreateDate")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategory = new SelectList(db.CarCategories, "ID", "NameCate", car.IdCategory);
            return View(car);
        }

        // GET: Admin/Cars/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Car car = db.Cars.Find(id);
        //    if (car == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(car);
        //}

        // POST: Admin/Cars/Delete/5
        [HttpPost]
        //public ActionResult DeleteConfirmed(int? id)
        //{
        //    Car car = db.Cars.Find(id);
        //    db.Cars.Remove(car);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public async Task<ActionResult> DeleteConfirmed(int? id, string category)
        {
            if (id.HasValue)
            {
                Car car = db.Cars.Find(id.Value);
                db.Cars.Remove(car);
                await db.SaveChangesAsync();
            }
            return Json(new { redirectUrl = Url.Action("Index", category), isRedirect = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangStatus(int id)
        {
            var result = new ChangeDAO().CartStatus(id);
            return Json(new
            {
                Status = result
            });
        }
        public async Task<string> ChangeImage(int? id , string picture)
        {
            pic = picture;
            if(pic == null)
            {
                return "Mã Không Tồn Tại";
            }

            Car car = db.Cars.Find(id);
            if(car == null)
            {
                return "Không Có Mã";
            }
            car.Images = picture;
            db.SaveChanges();
            return "";
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
