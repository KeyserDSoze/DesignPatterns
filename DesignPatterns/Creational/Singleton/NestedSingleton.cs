using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class NestedSingleton : IDesignPattern
    {
        private NestedSingleton()
        {
        }
        public static NestedSingleton Instance { get { return Nested.instance; } }
        private class Nested
        {
            static Nested()
            {
            }
            internal static readonly NestedSingleton instance = new NestedSingleton();
        }
    }
}
