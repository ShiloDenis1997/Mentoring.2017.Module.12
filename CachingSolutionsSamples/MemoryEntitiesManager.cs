using Cache.Infrastructure;
using NorthwindLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    public class MemoryEntitiesManager<T> where T : class
    {
        private readonly MemoryCache<IEnumerable<T>> _cache;

        public MemoryEntitiesManager(MemoryCache<IEnumerable<T>> cache)
        {
            _cache = cache;
        }

        public IEnumerable<T> GetEntities(CacheItemPolicy cachePolicy)
        {
            Console.WriteLine("Get Entities");
            var user = Thread.CurrentPrincipal.Identity.Name;
            var entities = _cache.Get(user);

            if (entities == null)
            {
                Console.WriteLine("From no cache storage");
                using (var dbContext = new Northwind())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;
                    entities = dbContext.Set<T>().ToList();
                }

                _cache.Set(user, entities, cachePolicy);
            }
            return entities;
        }
    }
}