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
    public class PortfolioDownsController : Controller
    {
        private Portfolio_Db db = new Portfolio_Db();

        // GET: Portfolio/PortfolioDowns
        public ActionResult Index()
        {
            return View(db.PortfolioDowns.ToList());
        }

        // GET: Portfolio/PortfolioDowns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioDown portfolioDown = db.PortfolioDowns.Find(id);
            if (portfolioDown == null)
            {
                return HttpNotFound();
            }
            return View(portfolioDown);
        }

        // GET: Portfolio/PortfolioDowns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/PortfolioDowns/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhotoPort")] PortfolioDown portfolioDown)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioDowns.Add(portfolioDown);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolioDown);
        }

        // GET: Portfolio/PortfolioDowns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioDown portfolioDown = db.PortfolioDowns.Find(id);
            if (portfolioDown == null)
            {
                return HttpNotFound();
            }
            return View(portfolioDown);
        }

        // POST: Portfolio/PortfolioDowns/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhotoPort")] PortfolioDown portfolioDown)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolioDown).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolioDown);
        }

        // GET: Portfolio/PortfolioDowns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioDown portfolioDown = db.PortfolioDowns.Find(id);
            if (portfolioDown == null)
            {
                return HttpNotFound();
            }
            return View(portfolioDown);
        }

        // POST: Portfolio/PortfolioDowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortfolioDown portfolioDown = db.PortfolioDowns.Find(id);
            db.PortfolioDowns.Remove(portfolioDown);
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
