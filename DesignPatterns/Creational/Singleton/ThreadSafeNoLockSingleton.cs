using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class ThreadSafeNoLockSingleton : DesignPattern, IDesignPattern
    {
        private ThreadSafeNoLockSingleton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        //autoproperty
        public static ThreadSafeNoLockSingleton Instance { get; } = new ThreadSafeNoLockSingleton();
    }
}
