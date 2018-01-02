using Cache.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingSolutionsSamples
{
    public class Fibonacci
    {
        private readonly ICache<int> _cache;

        public Fibonacci(ICache<int> cache)
        {
            _cache = cache;
        }

        public int ComputeFibonacci(int index)
        {
            if (index <= 0)
            {
                throw new ArgumentException($"{nameof(index)} must be positive number");
            }

            if (index == 1 || index == 2)
            {
                return 1;
            }

            int fromCache = _cache.Get(index.ToString());
            if (fromCache != default(int))
            {
                Console.WriteLine($"From cache: {fromCache}");
                return fromCache;
            }

            int result = ComputeFibonacci(index - 1) + ComputeFibonacci(index - 2);
            Console.WriteLine($"Computed: {result}");
            _cache.Set(index.ToString(), result);
            return result;
        }
    }
}
