using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using Cache.Infrastructure;
using NorthwindLibrary;
using System.Collections.Generic;

namespace CachingSolutionsSamples
{
    [TestClass]
    public class Task2Tests
    {
        private readonly string _categoriesPrefix = "Cache_Categories";
        private readonly string _customersPrefix = "Cache_Customers";
        private readonly string _suppliersPrefix = "Cache_Suppliers";

        [TestMethod]
        public void CategoriesMemoryCache()
        {
            var categoryManager = new EntitiesManager<Category>(new MemoryCache<IEnumerable<Category>>(_categoriesPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CategoriesRedisCache()
        {
            var categoryManager = new EntitiesManager<Category>(new RedisCache<IEnumerable<Category>>("localhost", _categoriesPrefix));
            
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CustomersMemoryCache()
        {
            var categoryManager = new EntitiesManager<Customer>(new MemoryCache<IEnumerable<Customer>>(_customersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CustomersRedisCache()
        {
            var categoryManager = new EntitiesManager<Customer>(new RedisCache<IEnumerable<Customer>>("localhost", _customersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void SuppliersMemoryCache()
        {
            var categoryManager = new EntitiesManager<Supplier>(new MemoryCache<IEnumerable<Supplier>>(_suppliersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void SuppliersRedisCache()
        {
            var categoryManager = new EntitiesManager<Supplier>(new RedisCache<IEnumerable<Supplier>>("localhost", _suppliersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(categoryManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }
    }
}