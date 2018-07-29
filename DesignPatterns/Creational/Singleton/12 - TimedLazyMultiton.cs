using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class TimedLazyMultiton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private static readonly ConcurrentDictionary<string, Lazy<TimedLazyMultiton>> Instances = new ConcurrentDictionary<string, Lazy<TimedLazyMultiton>>();
        public static TimedLazyMultiton GetInstance(string Key = "Test")
        {
            Lazy<TimedLazyMultiton> instance = Instances.GetOrAdd(Key, ø => new Lazy<TimedLazyMultiton>(() => new TimedLazyMultiton()));
            if (instance.Value.Expired)
            {
                Instances.TryUpdate(Key, new Lazy<TimedLazyMultiton>(() => new TimedLazyMultiton()), instance);
                instance = Instances.GetOrAdd(Key, ø => new Lazy<TimedLazyMultiton>(() => new TimedLazyMultiton()));
            }
            Console.WriteLine("Get Instance");
            return instance.Value;
        }
        private TimedLazyMultiton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        private DateTime LastTime = new DateTime(1970, 1, 1);
        private const int refreshedHours = 1;
        private bool Expired { get { return DateTime.Now.Subtract(LastTime).TotalHours > refreshedHours; } }
    }
}
