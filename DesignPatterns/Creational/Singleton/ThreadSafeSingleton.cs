using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class ThreadSafeSingleton : IDesignPattern
    {
        private static ThreadSafeSingleton instance = null;
        private static readonly object trafficlight = new object();
        ThreadSafeSingleton()
        {
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
                    return instance;
                }
            }
        }
    }
}
