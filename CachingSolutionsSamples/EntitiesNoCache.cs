using System.Collections.Generic;
using System.Linq;
using Cache.Infrastructure;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    public class EntitiesNoCache : IEntitiesNoCache
    {
        public IEnumerable<T> Get<T>() 
            where T : class
        {
            using (var dbContext = new Northwind())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                dbContext.Configuration.ProxyCreationEnabled = false;
                return dbContext.Set<T>().ToList();
            }
        }
    }
}
