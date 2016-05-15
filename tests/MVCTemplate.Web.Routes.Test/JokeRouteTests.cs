namespace MVCTemplate.Web.Routes.Test
{
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using System.Web.Routing;
    [TestFixture]
    public class JokeRouteTests
    {
        [Test]
        public void TestRouteById()
        {
            var routeCollection = new RouteCollection();
            const string Url = "/Joke/NDk3MTMxNDM=";

            RouteConfig.RegisterRoutes(routeCollection);

            routeCollection.ShouldMap(Url).To<JokesController>(c=>c.ById("NDk3MTMxNDM="));
        }
    }
}
