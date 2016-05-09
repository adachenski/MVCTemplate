using MVCTemplate.Data;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Model;
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
        private IDbRepository<Joke> jokes;
        private IDbRepository<JokeCategory> jokeCategories;

        public HomeController(IDbRepository<Joke> j, IDbRepository<JokeCategory> jk)
        {
            this.jokes = j;
            this.jokeCategories = jk;
        }

        // Poor Man's Dependancy Injection
        /* public HomeController()
         {
            var dbContext = new ApplicationDbContext();

             // if not autofac, ninject or other dependancy injector
             this.jokes = new DbRepository<Joke>(dbContext);
             this.jokeCategories = new DbRepository<JokeCategory>(dbContext);

            // We can add this to seed method just to create some rndom jokes
             var category = new JokeCategory { Name = "Delete MEEEE" };

             this.jokeCategories.Add(category);

             for (int i = 0; i < 6; i++)
             {
                 var joke = new Joke { Content = "Random content" + i, Category = category };
                 this.jokes.Add(joke);
             }

             this.jokes.Save();
             this.jokeCategories.Save();
             }*/

        public ActionResult Index()
        {
            // Trace.WriteLine("Nasko is in Home ");
            // var db = new ApplicationDbContext();
            // var userCount = db.Users.Count();

            // Take 3 random jokes
            var jokes = this.jokes.All().OrderBy(x => Guid.NewGuid()).Take(3);

            return this.View(jokes);
        }
    }
}