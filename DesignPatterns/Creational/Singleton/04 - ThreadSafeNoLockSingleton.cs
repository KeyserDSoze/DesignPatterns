﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class ThreadSafeNoLockSingleton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private ThreadSafeNoLockSingleton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
            Console.WriteLine("Autoproperty, in this case, does not show \"Get Instance\" due to my will to not change the beauty of code.");
        }
        //autoproperty
        public static ThreadSafeNoLockSingleton Instance { get; } = new ThreadSafeNoLockSingleton();
        public static void Test() { Console.WriteLine("When you call this static Method the instance is however created."); return; }
    }
}
