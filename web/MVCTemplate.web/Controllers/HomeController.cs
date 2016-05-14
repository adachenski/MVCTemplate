using AutoMapper.QueryableExtensions;
using MVCTemplate.Data;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Model;
using MVCTemplate.Services.Data;
using MVCTemplate.Services.Web;
using MVCTemplate.Web.Infrastructure.Mapping;
using MVCTemplate.Web.ViewModels.Home;
using System;
using System.Linq;
using System.Web.Mvc;
using static MVCTemplate.Web.App_Start.AutofacConfig;

namespace MVCTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        /*private IDbRepository<Joke> jokes;
        private IDbRepository<JokeCategory> jokeCategories;

        public HomeController(IDbRepository<Joke> j, IDbRepository<JokeCategory> jk)
        {
            this.jokes = j;
            this.jokeCategories = jk;
        }*/

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

        private IJokeService jokes;
        private ICategoryService jokeCategories;
        private IChacheService cacheServicel;

        public HomeController(IJokeService j, ICategoryService jk, IChacheService cacheServ)
        {
            this.jokes = j;
            this.jokeCategories = jk;
            this.cacheServicel = cacheServ;
        }

        public ActionResult Index()
        {
            // Trace.WriteLine("Nasko is in Home "); //Shows info in Glimple Trace bar
            // var db = new ApplicationDbContext();
            // var userCount = db.Users.Count();

            // Take 3 random jokes no AutoMapper
            // var jokes = this.jokes.All().OrderBy(x => Guid.NewGuid())
            //     .Take(3).Select(x => new JokeViewModel() { Content = x.Content }).ToList();

            // Take 3 random jokes with AutoMapper
            // var jokes2 = this.jokes.All().OrderBy(x => Guid.NewGuid())
            //     .Take(3).ProjectTo<JokeViewModel>(AutoMapperConfig.Configuration).ToList();

            // Take 3 jokes after makeing IQueriable extensions (overridind ProjectTo from AtoMapper)
            // var jokes3 = this.jokes.All().OrderBy(x => Guid.NewGuid()).Take(3)
            // .To<JokeViewModel>().ToList();
            var joke = this.jokes.GetRandomJokes(3)
                .To<JokeViewModel>().ToList();

            var categories = this.cacheServicel.Get(
                "category",
                () => this.jokeCategories.GetAll()
                 .To<JokeCategoryViewModel>()
                 .ToList(), 30 * 60);

            var viewModel = new IndexViewModel
            {
                Jokes = joke,
                Categories = categories
            };

            return this.View(viewModel);
        }
    }
}