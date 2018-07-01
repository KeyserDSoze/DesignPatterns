using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Creational.Singleton;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var xx = ThreadSafeNoLockSingleton.Instance;
            var yy = ThreadSafeNoLockSingleton.Instance;
            Console.ReadLine();
        }
    }
}
