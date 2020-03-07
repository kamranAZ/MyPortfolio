using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio_CV.Areas.Portfolio.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Portfolio/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}