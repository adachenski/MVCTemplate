namespace MVCTemplate.Web.ViewModels.Home
{
    using AutoMapper;
    using MVCTemplate.Data.Model;
    using MVCTemplate.Web.Infrastructure.Mapping;

    public class JokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string Category { get; set; }

        public void CreateMappings(IMapperConfiguration config)
        {
            config.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}