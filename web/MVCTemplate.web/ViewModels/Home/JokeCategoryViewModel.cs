namespace MVCTemplate.Web.ViewModels.Home
{
    using MVCTemplate.Data.Model;
    using MVCTemplate.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}