using System.Collections.Generic;

namespace Cache.Infrastructure
{
    public interface IEntitiesCache<T> where T: class
    {
        IEnumerable<T> Get(string forUser);
        void Set(string forUser, IEnumerable<T> categories);
    }
}
