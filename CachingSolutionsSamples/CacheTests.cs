using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using Cache.Infrastructure;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void MemoryCache()
        {
            var categoryManager = new EntitiesManager<Category>(new CategoriesMemoryCache(), new EntitiesNoCache());

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void RedisCache()
        {
            var categoryManager = new EntitiesManager<Category>(new CategoriesRedisCache("localhost"), new EntitiesNoCache());

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }
    }
}