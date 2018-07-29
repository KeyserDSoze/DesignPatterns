using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class LazyMultiton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private static readonly ConcurrentDictionary<string, Lazy<LazyMultiton>> Instances = new ConcurrentDictionary<string, Lazy<LazyMultiton>>();
        public static LazyMultiton GetInstance(string Key = "Test")
        {
            Lazy<LazyMultiton> instance = Instances.GetOrAdd(Key, ø => new Lazy<LazyMultiton>(() => new LazyMultiton()));
            Console.WriteLine("Get Instance");
            return instance.Value;
        }
        private LazyMultiton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
    }
}
