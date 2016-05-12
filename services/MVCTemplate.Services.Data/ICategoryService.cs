namespace MVCTemplate.Services.Data
{
    using MVCTemplate.Data.Model;
    using System.Linq;
    using System;
    using MVCTemplate.Data.Common;
    public interface ICategoryService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnshureCategory(string name);
    }
}
