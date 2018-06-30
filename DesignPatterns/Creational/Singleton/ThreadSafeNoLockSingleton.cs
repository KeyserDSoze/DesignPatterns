using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class ThreadSafeNoLockSingleton : IDesignPattern
    {
        private static readonly ThreadSafeNoLockSingleton instance = new ThreadSafeNoLockSingleton();
        static ThreadSafeNoLockSingleton()
        {
        }
        private ThreadSafeNoLockSingleton()
        {
        }
        public static ThreadSafeNoLockSingleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
