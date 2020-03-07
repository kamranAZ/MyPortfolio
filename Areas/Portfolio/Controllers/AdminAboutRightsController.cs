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
    public class AdminAboutRightsController : Controller
    {
        private Portfolio_Db db = new Portfolio_Db();

        // GET: Portfolio/AdminAboutRights
        public ActionResult Index()
        {
            return View(db.AboutRights.ToList());
        }

        // GET: Portfolio/AdminAboutRights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutRight aboutRight = db.AboutRights.Find(id);
            if (aboutRight == null)
            {
                return HttpNotFound();
            }
            return View(aboutRight);
        }

        // GET: Portfolio/AdminAboutRights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/AdminAboutRights/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Descript")] AboutRight aboutRight)
        {
            if (ModelState.IsValid)
            {
                db.AboutRights.Add(aboutRight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutRight);
        }

        // GET: Portfolio/AdminAboutRights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutRight aboutRight = db.AboutRights.Find(id);
            if (aboutRight == null)
            {
                return HttpNotFound();
            }
            return View(aboutRight);
        }

        // POST: Portfolio/AdminAboutRights/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Descript")] AboutRight aboutRight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutRight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutRight);
        }

        // GET: Portfolio/AdminAboutRights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutRight aboutRight = db.AboutRights.Find(id);
            if (aboutRight == null)
            {
                return HttpNotFound();
            }
            return View(aboutRight);
        }

        // POST: Portfolio/AdminAboutRights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutRight aboutRight = db.AboutRights.Find(id);
            db.AboutRights.Remove(aboutRight);
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
