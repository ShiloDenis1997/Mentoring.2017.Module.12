using System.Collections.Generic;
using NorthwindLibrary;
using System.Runtime.Caching;
using Cache.Infrastructure;

namespace CachingSolutionsSamples
{
    internal class CategoriesMemoryCache : IEntitiesCache<Category>
    {
        readonly ObjectCache _cache = MemoryCache.Default;
        string prefix = "Cache_Categories";

        public IEnumerable<Category> Get(string forUser)
        {
            return (IEnumerable<Category>) _cache.Get(prefix + forUser);
        }

        public void Set(string forUser, IEnumerable<Category> categories)
        {
            _cache.Set(prefix + forUser, categories, ObjectCache.InfiniteAbsoluteExpiration);
        }
    }
}
