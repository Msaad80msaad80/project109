using project109.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project109.Controllers
{
    public class HomeController : Controller
    {
        private msaadtestEntities db = new msaadtestEntities();
        public ActionResult Index()
        {
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
        public ActionResult latestbooks()
        {
            var latestbooks = db.view_books.Where(a => a.active == true).Take(5).OrderByDescending(a => a.Id).ToList();
            return PartialView(latestbooks);
        }
    }
}