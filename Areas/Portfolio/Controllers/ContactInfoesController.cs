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
    public class ContactInfoesController : Controller
    {
        private Portfolio_Db db = new Portfolio_Db();

        // GET: Portfolio/ContactInfoes
        public ActionResult Index()
        {
            return View(db.ContactInfoes.ToList());
        }

        // GET: Portfolio/ContactInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // GET: Portfolio/ContactInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/ContactInfoes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Phone,Email,Addres,FbLink,TwLink,ItgLink,GoLink,TelLink,InLink")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.ContactInfoes.Add(contactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactInfo);
        }

        // GET: Portfolio/ContactInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // POST: Portfolio/ContactInfoes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Phone,Email,Addres,FbLink,TwLink,ItgLink,GoLink,TelLink,InLink")] ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactInfo);
        }

        // GET: Portfolio/ContactInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            if (contactInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactInfo);
        }

        // POST: Portfolio/ContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactInfo contactInfo = db.ContactInfoes.Find(id);
            db.ContactInfoes.Remove(contactInfo);
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
