using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Portfolio_CV.Model;

namespace Portfolio_CV.Areas.Portfolio.Controllers
{
    public class AdminAboutLeftController : Controller
    {
        private Portfolio_Db db = new Portfolio_Db();

        // GET: Portfolio/AdminAboutLeft
        public ActionResult Index()
        {
            return View(db.AboutLefts.ToList());
        }

        // GET: Portfolio/AdminAboutLeft/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutLeft aboutLeft = db.AboutLefts.Find(id);
            if (aboutLeft == null)
            {
                return HttpNotFound();
            }
            return View(aboutLeft);
        }

        // GET: Portfolio/AdminAboutLeft/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/AdminAboutLeft/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MyPhoto")] AboutLeft aboutLeft, HttpPostedFileBase aboutleftPost)
        {
            if (ModelState.IsValid)
            {
                if (aboutleftPost != null)
                {
                    if (aboutleftPost != null)
                    {
                        if (aboutleftPost.ContentLength > 0)
                        {
                            if (aboutleftPost.ContentType.ToLower() == "image/jpg" ||
                                aboutleftPost.ContentType.ToLower() == "image/jpeg" ||
                                    aboutleftPost.ContentType.ToLower() == "image/gif" ||
                                aboutleftPost.ContentType.ToLower() == "image/png")
                            {
                                WebImage img = new WebImage(aboutleftPost.InputStream);
                                FileInfo flInfo = new FileInfo(aboutleftPost.FileName);
                                string filename = "AboutLeft" + Guid.NewGuid() + flInfo.Extension;
                                img.Save("~/Upload/AboutLeft/" + filename);
                                aboutLeft.MyPhoto = "/Upload/AboutLeft/" + filename;
                            }
                        }
                    }
                }
                db.AboutLefts.Add(aboutLeft);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutLeft);
        }

        // GET: Portfolio/AdminAboutLeft/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutLeft aboutLeft = db.AboutLefts.Find(id);
            if (aboutLeft == null)
            {
                return HttpNotFound();
            }
            return View(aboutLeft);
        }


        // POST: Portfolio/AdminAboutLeft/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "Id,MyPhoto")] AboutLeft aboutLeft)
        {

            if (ModelState.IsValid)
            {
                db.Entry(aboutLeft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutLeft);
        }

        // GET: Portfolio/AdminAboutLeft/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutLeft aboutLeft = db.AboutLefts.Find(id);
            if (aboutLeft == null)
            {
                return HttpNotFound();
            }
            return View(aboutLeft);
        }

        // POST: Portfolio/AdminAboutLeft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutLeft aboutLeft = db.AboutLefts.Find(id);
            db.AboutLefts.Remove(aboutLeft);
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
