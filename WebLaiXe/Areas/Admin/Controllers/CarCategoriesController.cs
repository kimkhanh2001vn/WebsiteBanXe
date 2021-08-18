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

namespace WebLaiXe.Areas.Admin.Controllers
{
    public class CarCategoriesController : BaseController
    {
        private BanXeDB db = new BanXeDB();

        // GET: Admin/CarCategories
        public ActionResult Index(int? page)
        {
            int isize = 6;
            int iPageNum = (page ?? 1);
            var carcategory = db.CarCategories.Where(x => x.Status == true).ToList();
            return View(carcategory.OrderByDescending(x => x.CreateDate).ToPagedList(iPageNum, isize));
        }

        // GET: Admin/CarCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }

        // GET: Admin/CarCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CarCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameCate,Images,Status,CreateDate")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                db.CarCategories.Add(carCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carCategory);
        }

        // GET: Admin/CarCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }

        // POST: Admin/CarCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Images,Status,CreateDate")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carCategory);
        }

        // GET: Admin/CarCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarCategory carCategory = db.CarCategories.Find(id);
            if (carCategory == null)
            {
                return HttpNotFound();
            }
            return View(carCategory);
        }

        // POST: Admin/CarCategories/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int? id, string category)
        {
            if (id.HasValue)
            {
                CarCategory carCategory = db.CarCategories.Find(id.Value);
                db.CarCategories.Remove(carCategory);
                await db.SaveChangesAsync();
            }
            return Json(new { redirectUrl = Url.Action("Index", category), isRedirect = true }, JsonRequestBehavior.AllowGet);
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
