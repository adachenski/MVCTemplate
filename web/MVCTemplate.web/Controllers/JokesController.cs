namespace MVCTemplate.Web.Controllers
{
    using Infrastructure.Mapping;
    using Services.Data;
    using Services.Web;
    using System.Web.Mvc;
    using ViewModels.Home;
    public class JokesController : BaseController
    {
        private IIdentifierProvider identifierProvider;
        private IJokeService jokes;

        public JokesController(
            IIdentifierProvider identifierProvider,
            IJokeService jokes)
        {
            this.identifierProvider = identifierProvider;
            this.jokes = jokes;
        }

        public ActionResult ById(string id)
        {
            var joke = this.jokes.GetById(id);
            var viewModel = AutoMapperConfig.Configuration.CreateMapper().Map<JokeViewModel>(joke);
            return this.View(viewModel);
        }
    }
}