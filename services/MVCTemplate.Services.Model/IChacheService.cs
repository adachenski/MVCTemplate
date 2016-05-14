namespace MVCTemplate.Services.Web
{
    using System;

    public interface IChacheService
    {
        T Get<T>(string name, Func<T> getDataFunc, int durationInSeconds);

        void Remove(string name);
    }
}
