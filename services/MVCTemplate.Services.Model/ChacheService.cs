namespace MVCTemplate.Services.Web {  
    using System;
    using System.Web;
    using System.Web.Caching;

    public class ChacheService : IChacheService
    {
        private static readonly object lockObject = new object();
        public T Get<T>(string name, Func<T> getDataFunc, int durationInSeconds)
        {
            if (HttpRuntime.Cache[name] == null)
            {
                lock (lockObject)
                {
                    if (HttpRuntime.Cache[name] == null)
                    {
                        var data = getDataFunc();
                        HttpRuntime.Cache.Insert(
                            name,
                            data,
                            null,
                            DateTime.Now.AddSeconds(durationInSeconds),
                            Cache.NoSlidingExpiration
                            );
                    }
                }
            }
            return (T)HttpRuntime.Cache[name];
        }

        public void Remove(string name)
        {
            HttpRuntime.Cache.Remove(name);
        }
    }
}
