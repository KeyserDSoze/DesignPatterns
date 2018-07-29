using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.ServiceLocator
{
    public class LazyServiceLocator : DesignPattern, IDesignPattern
    {
        public static LazyServiceLocator Instance
        {
            get
            {
                LazyLocator.GetInstance<DatabaseE>().Save();
                LazyLocator.GetInstance<DatabaseF>().Save();
                return null;
            }
        }
    }
    public class LazyLocator
    {
        private static LazyLocator lazyLocator;
        private static readonly ConcurrentDictionary<Type, Lazy<ILazyServiceLocator>> servicecontainer = new ConcurrentDictionary<Type, Lazy<ILazyServiceLocator>>();
        
        public static T GetInstance<T>() where T : ILazyServiceLocator
        {
            Lazy<ILazyServiceLocator> instance = servicecontainer.GetOrAdd(typeof(T), ø => new Lazy<ILazyServiceLocator>(() => (ILazyServiceLocator)Activator.CreateInstance(typeof(T), null)));
            return (T)instance.Value;
        }
    }
    public interface ILazyServiceLocator
    {
        void Save();
    }

    public class DatabaseE : ILazyServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in E");
        }
    }
    public class DatabaseF : ILazyServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in F");
        }
    }
}
