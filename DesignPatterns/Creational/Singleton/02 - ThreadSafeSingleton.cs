using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class ThreadSafeSingleton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private static ThreadSafeSingleton instance = null;
        private static readonly object trafficlight = new object();
        ThreadSafeSingleton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        public static ThreadSafeSingleton Instance
        {
            get
            {
                lock (trafficlight)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingleton();
                    }
                    Console.WriteLine("Get Instance");
                    return instance;
                }
            }
        }
    }
}
