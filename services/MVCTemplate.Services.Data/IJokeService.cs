namespace MVCTemplate.Services.Data
{
    using MVCTemplate.Data.Model;
    using System.Linq; 

    public interface IJokeService
    {
        IQueryable<Joke> GetRandomJokes(int count);
    }
}
