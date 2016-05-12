namespace MVCTemplate.Services.Data
{
    using MVCTemplate.Data.Common;
    using MVCTemplate.Data.Model;
    using System;
    using System.Linq;

    public class JokeService : IJokeService
    {
        IDbRepository<Joke> jokes;
        public JokeService(IDbRepository<Joke> jokess)
        {
            this.jokes = jokess;
        }

        public IQueryable<Joke> GetRandomJokes(int count)
        {
            return this.jokes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
