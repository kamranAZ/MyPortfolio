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
    public class SosialsController : Controller
    {
        private Portfolio_Db db = new Portfolio_Db();

        // GET: Portfolio/Sosials
        public ActionResult Index()
        {
            return View(db.Sosials.ToList());
        }

        // GET: Portfolio/Sosials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sosial sosial = db.Sosials.Find(id);
            if (sosial == null)
            {
                return HttpNotFound();
            }
            return View(sosial);
        }

        // GET: Portfolio/Sosials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/Sosials/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Links,Icons")] Sosial sosial)
        {
            if (ModelState.IsValid)
            {
                db.Sosials.Add(sosial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sosial);
        }

        // GET: Portfolio/Sosials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sosial sosial = db.Sosials.Find(id);
            if (sosial == null)
            {
                return HttpNotFound();
            }
            return View(sosial);
        }

        // POST: Portfolio/Sosials/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Links,Icons")] Sosial sosial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sosial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sosial);
        }

        // GET: Portfolio/Sosials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sosial sosial = db.Sosials.Find(id);
            if (sosial == null)
            {
                return HttpNotFound();
            }
            return View(sosial);
        }

        // POST: Portfolio/Sosials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sosial sosial = db.Sosials.Find(id);
            db.Sosials.Remove(sosial);
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
