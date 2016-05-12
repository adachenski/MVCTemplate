namespace Crawer
{
    using AngleSharp;
    using MVCTemplate.Data;
    using MVCTemplate.Services.Data;
    using System;
    using MVCTemplate.Data.Model;
    using MVCTemplate.Data.Common;

    public static class Program
    {
        public static void Main()
        {
            var db = new ApplicationDbContext();
            var repo = new DbRepository<JokeCategory>(db);
            var categoryService = new CategoryService(repo);
            var configuration = Configuration.Default.WithDefaultLoader();
            var brousingContext = BrowsingContext.New(configuration);

            for (int i = 1; i <= 1000; i++)
            {
                var Url = $"http://vicove.com/vic-{i}";
               var doc =  brousingContext.OpenAsync(Url).Result;
               var jokeContent =  doc.QuerySelector("#content_box .post-content").TextContent.Trim();
                if (!string.IsNullOrWhiteSpace(jokeContent))
                {
                    var categoryName = doc.QuerySelector("#content_box .thecategory a").TextContent.Trim();
                    var category = categoryService.EnshureCategory(categoryName);
                    var joke = new Joke() { Category = category, Content = jokeContent };
                    db.Jokes.Add(joke);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            }
        }
    }
}
