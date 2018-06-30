using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public class LazyV4Singleton : IDesignPattern
    {
        private static readonly Lazy<LazyV4Singleton> lazy = new Lazy<LazyV4Singleton>(() => new LazyV4Singleton());
        public static LazyV4Singleton Instance { get { return lazy.Value; } }
        private LazyV4Singleton()
        {
        }
    }
}
