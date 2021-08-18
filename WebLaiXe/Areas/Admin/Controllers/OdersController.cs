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
    public class OdersController : BaseController
    {
        private BanXeDB db = new BanXeDB();

        // GET: Admin/Oders
        public ActionResult Index()
        {
            return View(db.Oders.ToList());
        }

        // GET: Admin/Oders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oder oder = db.Oders.Find(id);
            if (oder == null)
            {
                return HttpNotFound();
            }
            return View(oder);
        }

        // GET: Admin/Oders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Oders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CusName,CusAddress,CusEmail,CusPhoneNumber,CreatedDate,CustomerID,Status")] Oder oder)
        {
            if (ModelState.IsValid)
            {
                db.Oders.Add(oder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oder);
        }

        // GET: Admin/Oders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oder oder = db.Oders.Find(id);
            if (oder == null)
            {
                return HttpNotFound();
            }
            return View(oder);
        }

        // POST: Admin/Oders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CusName,CusAddress,CusEmail,CusPhoneNumber,CreatedDate,CustomerID,Status")] Oder oder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oder);
        }

        // GET: Admin/Oders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Oder oder = db.Oders.Find(id);
        //    if (oder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(oder);
        //}

        //// POST: Admin/Oders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Oder oder = db.Oders.Find(id);
        //    db.Oders.Remove(oder);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(int? id, string category)
        {
            if (id.HasValue)
            {
                Oder oder = db.Oders.Find(id);
                db.Oders.Remove(oder);
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
