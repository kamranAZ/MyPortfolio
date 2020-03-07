using Portfolio_CV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio_CV.Controllers
{
    public class HomeController : Controller
    {
        Portfolio_Db db = new Portfolio_Db();
        public ActionResult Index()
        {
            ViewBag.aboutImg = db.AboutLefts.ToList();
            ViewBag.aboutRight = db.AboutRights.ToList();
            ViewBag.servicesss = db.Services.ToList();
            ViewBag.portUp = db.PortfolioUps.ToList();
            ViewBag.portDown = db.PortfolioDowns.ToList();
            ViewBag.JourJr = db.Journals.ToList();
            ViewBag.Contact = db.ContactInfoes.First();
            ViewBag.Sosiality = db.Sosials.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}