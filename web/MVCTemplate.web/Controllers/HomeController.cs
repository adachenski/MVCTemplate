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
        public ActionResult Index()
        {
            Trace.WriteLine("Nasko is in Home ");
            var db = new ApplicationDbContext();
            var userCount = db.Users.Count();

            return this.View();
        }
    }
}