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
    public class DocDetailsController : Controller
    {
        private BanXeDB db = new BanXeDB();

        // GET: Admin/DocDetails
        public ActionResult Index()
        {
            var docDetails = db.DocDetails.Include(d => d.Document);
            return View(docDetails.ToList());
        }

        // GET: Admin/DocDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocDetail docDetail = db.DocDetails.Find(id);
            if (docDetail == null)
            {
                return HttpNotFound();
            }
            return View(docDetail);
        }

        // GET: Admin/DocDetails/Create
        public ActionResult Create()
        {
            ViewBag.DocID = new SelectList(db.Documents, "ID", "NameDoc");
            return View();
        }

        // POST: Admin/DocDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DocID,Content,Images,CreateDate,Status")] DocDetail docDetail)
        {
            if (ModelState.IsValid)
            {
                db.DocDetails.Add(docDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocID = new SelectList(db.Documents, "ID", "NameDoc", docDetail.DocID);
            return View(docDetail);
        }

        // GET: Admin/DocDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocDetail docDetail = db.DocDetails.Find(id);
            if (docDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocID = new SelectList(db.Documents, "ID", "NameDoc", docDetail.DocID);
            return View(docDetail);
        }

        // POST: Admin/DocDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DocID,Content,Images,CreateDate,Status")] DocDetail docDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocID = new SelectList(db.Documents, "ID", "NameDoc", docDetail.DocID);
            return View(docDetail);
        }

        // GET: Admin/DocDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocDetail docDetail = db.DocDetails.Find(id);
            if (docDetail == null)
            {
                return HttpNotFound();
            }
            return View(docDetail);
        }

        // POST: Admin/DocDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocDetail docDetail = db.DocDetails.Find(id);
            db.DocDetails.Remove(docDetail);
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
