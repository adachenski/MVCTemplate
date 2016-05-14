namespace MVCTemplate.Web.Controllers
{
    using Services.Web;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        public IChacheService Cache { get; set; }
    }
}