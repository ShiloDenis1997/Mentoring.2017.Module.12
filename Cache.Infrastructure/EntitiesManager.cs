using System;
using System.Collections.Generic;
using System.Threading;

namespace Cache.Infrastructure
{
    public class EntitiesManager<T> where T: class
    {
        private readonly IEntitiesCache<T> _cache;
        private readonly IEntitiesNoCache _noCache;

        public EntitiesManager(IEntitiesCache<T> cache, IEntitiesNoCache noCache)
        {
            _cache = cache;
            _noCache = noCache;
        }

        public IEnumerable<T> GetEntities()
        {
            Console.WriteLine("Get Entities");
            var user = Thread.CurrentPrincipal.Identity.Name;
            var entities = _cache.Get(user);

            if (entities == null)
            {
                Console.WriteLine("From no cache storage");
                entities = _noCache.Get<T>();
                _cache.Set(user, entities);
            }

            return entities;
        }
    }
}