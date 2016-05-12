namespace MVCTemplate.Services.Data
{
    using MVCTemplate.Data.Common;
    using MVCTemplate.Data.Model;
    using System.Linq;
    using System;

    public class CategoryService : ICategoryService
    {
        IDbRepository<JokeCategory> categories;
        public CategoryService(IDbRepository<JokeCategory> categoriess)
        {
            this.categories = categoriess;
        }

        public JokeCategory EnshureCategory(string name)
        {
            var category = this.categories.All().FirstOrDefault(x => x.Name == name);
            if (category!=null)
            {
                return category;
            }
            category = new JokeCategory() { Name = name};
            this.categories.Add(category);
            this.categories.Save();
            return category;
        }

        public IQueryable<JokeCategory> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
