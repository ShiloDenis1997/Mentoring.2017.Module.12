using System.Collections.Generic;
using NorthwindLibrary;
using StackExchange.Redis;
using System.IO;
using System.Runtime.Serialization;
using Cache.Infrastructure;

namespace CachingSolutionsSamples
{
    class CategoriesRedisCache : IEntitiesCache<Category>
    {
        private readonly ConnectionMultiplexer _redisConnection;
        string prefix = "Cache_Categories";

        readonly DataContractSerializer _serializer = new DataContractSerializer(
            typeof(IEnumerable<Category>));

        public CategoriesRedisCache(string hostName)
        {
            var options = new ConfigurationOptions()
            {
                AbortOnConnectFail = false,
                EndPoints = { hostName }
            };
            _redisConnection = ConnectionMultiplexer.Connect(options);
        }

        public IEnumerable<Category> Get(string forUser)
        {
            var db = _redisConnection.GetDatabase();
            byte[] s = db.StringGet(prefix + forUser);
            if (s == null)
                return null;

            return (IEnumerable<Category>) _serializer
                .ReadObject(new MemoryStream(s));

        }

        public void Set(string forUser, IEnumerable<Category> categories)
        {
            var db = _redisConnection.GetDatabase();
            var key = prefix + forUser;

            if (categories == null)
            {
                db.StringSet(key, RedisValue.Null);
            }
            else
            {
                var stream = new MemoryStream();
                _serializer.WriteObject(stream, categories);
                db.StringSet(key, stream.ToArray());
            }
        }
    }
}