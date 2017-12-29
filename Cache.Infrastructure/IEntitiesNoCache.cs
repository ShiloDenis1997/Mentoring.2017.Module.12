using System.Collections.Generic;

namespace Cache.Infrastructure
{
    public interface IEntitiesNoCache
    {
        IEnumerable<T> Get<T>() where T: class;
    }
}
