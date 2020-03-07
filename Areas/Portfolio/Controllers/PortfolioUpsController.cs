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
    public class PortfolioUpsController : Controller
    {
        private Portfolio_Db db = new Portfolio_Db();

        // GET: Portfolio/PortfolioUps
        public ActionResult Index()
        {
            return View(db.PortfolioUps.ToList());
        }

        // GET: Portfolio/PortfolioUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioUp portfolioUp = db.PortfolioUps.Find(id);
            if (portfolioUp == null)
            {
                return HttpNotFound();
            }
            return View(portfolioUp);
        }

        // GET: Portfolio/PortfolioUps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/PortfolioUps/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NamePort")] PortfolioUp portfolioUp)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioUps.Add(portfolioUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolioUp);
        }

        // GET: Portfolio/PortfolioUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioUp portfolioUp = db.PortfolioUps.Find(id);
            if (portfolioUp == null)
            {
                return HttpNotFound();
            }
            return View(portfolioUp);
        }

        // POST: Portfolio/PortfolioUps/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NamePort")] PortfolioUp portfolioUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolioUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolioUp);
        }

        // GET: Portfolio/PortfolioUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioUp portfolioUp = db.PortfolioUps.Find(id);
            if (portfolioUp == null)
            {
                return HttpNotFound();
            }
            return View(portfolioUp);
        }

        // POST: Portfolio/PortfolioUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortfolioUp portfolioUp = db.PortfolioUps.Find(id);
            db.PortfolioUps.Remove(portfolioUp);
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
