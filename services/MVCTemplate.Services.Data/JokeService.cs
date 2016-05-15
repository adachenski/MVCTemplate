namespace MVCTemplate.Services.Data
{
    using MVCTemplate.Data.Common;
    using MVCTemplate.Data.Model;
    using System;
    using System.Linq;
    using Web;
    public class JokeService : IJokeService
    {
        IDbRepository<Joke> jokes;
        IIdentifierProvider identifierProvider;
        public JokeService(
            IDbRepository<Joke> jokess,
            IIdentifierProvider idProvider)
        {
            this.jokes = jokess;
            this.identifierProvider = idProvider;
        }

        public Joke GetById(string id)
        {
            var intId = this.identifierProvider.Decode(id);
            var joke = this.jokes.GetById(intId);
            return joke;
        }

        public IQueryable<Joke> GetRandomJokes(int count)
        {
            return this.jokes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
