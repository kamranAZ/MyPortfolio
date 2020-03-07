using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio_CV.Model;

namespace Portfolio_CV.Areas.Portfolio.Controllers
{
    public class AdminHeadersController : Controller
    {
        private Portfolio_Db db = new Portfolio_Db();

        // GET: Portfolio/AdminHeaders
        public ActionResult Index()
        {
            return View(db.Headers.ToList());
        }

        // GET: Portfolio/AdminHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // GET: Portfolio/AdminHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/AdminHeaders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AboutMe")] Header header)
        {
            if (ModelState.IsValid)
            {
                db.Headers.Add(header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(header);
        }

        // GET: Portfolio/AdminHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // POST: Portfolio/AdminHeaders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AboutMe")] Header header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(header).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(header);
        }

        // GET: Portfolio/AdminHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // POST: Portfolio/AdminHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Header header = db.Headers.Find(id);
            db.Headers.Remove(header);
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
