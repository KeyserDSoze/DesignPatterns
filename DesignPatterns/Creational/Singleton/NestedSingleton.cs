﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class NestedSingleton : DesignPattern, IDesignPattern
    {
        private NestedSingleton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        public static NestedSingleton Instance { get { return Nested.instance; } }
        private class Nested
        {
            internal static readonly NestedSingleton instance = new NestedSingleton();
        }
    }
}
