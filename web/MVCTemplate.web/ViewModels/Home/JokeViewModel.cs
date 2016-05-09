namespace MVCTemplate.Web.ViewModels.Home
{
    using MVCTemplate.Data.Model;
    using MVCTemplate.Web.Infrastructure.Mapping;

    public class JokeViewModel : IMapFrom<Joke>, IMapTo<Joke>
    {
        public string Content { get; set; }
    }
}