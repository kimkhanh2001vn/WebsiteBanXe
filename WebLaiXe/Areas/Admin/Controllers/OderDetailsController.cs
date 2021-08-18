using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebLaiXe;

namespace WebLaiXe.Areas.Admin.Controllers
{
    public class OderDetailsController : BaseController
    {
        private BanXeDB db = new BanXeDB();

        // GET: Admin/OderDetails
        public ActionResult Index()
        {
            var oderDetails = db.OderDetails.Include(o => o.Oder);
            return View(oderDetails.ToList());
        }

        // GET: Admin/OderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OderDetail oderDetail = db.OderDetails.Find(id);
            if (oderDetail == null)
            {
                return HttpNotFound();
            }
            return View(oderDetail);
        }

        // GET: Admin/OderDetails/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Oders, "ID", "CusName");
            return View();
        }

        // POST: Admin/OderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrderID,CarID,Quantity,Price,Total")] OderDetail oderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OderDetails.Add(oderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Oders, "ID", "CusName", oderDetail.OrderID);
            return View(oderDetail);
        }

        // GET: Admin/OderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OderDetail oderDetail = db.OderDetails.Find(id);
            if (oderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Oders, "ID", "CusName", oderDetail.OrderID);
            return View(oderDetail);
        }

        // POST: Admin/OderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderID,CarID,Quantity,Price,Total")] OderDetail oderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Oders, "ID", "CusName", oderDetail.OrderID);
            return View(oderDetail);
        }

        // GET: Admin/OderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OderDetail oderDetail = db.OderDetails.Find(id);
            if (oderDetail == null)
            {
                return HttpNotFound();
            }
            return View(oderDetail);
        }

        // POST: Admin/OderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OderDetail oderDetail = db.OderDetails.Find(id);
            db.OderDetails.Remove(oderDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
