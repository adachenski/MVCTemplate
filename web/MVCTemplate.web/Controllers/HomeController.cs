using MVCTemplate.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVCTemplate.Web.App_Start.AutofacConfig;

namespace MVCTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        private IService service;


        public HomeController(IService ser)
        {
            this.service = ser;
        }

        public ActionResult Index()
        {
            this.service.Work();
            Trace.WriteLine("Nasko is in Home ");
            var db = new ApplicationDbContext();
            var userCount = db.Users.Count();

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