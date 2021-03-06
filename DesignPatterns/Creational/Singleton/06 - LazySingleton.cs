﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class LazySingleton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());
        public static LazySingleton Instance { get { Console.WriteLine("Get Instance"); return lazy.Value; } }
        private LazySingleton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
    }
}
