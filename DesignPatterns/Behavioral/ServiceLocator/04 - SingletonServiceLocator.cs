using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ServiceLocator
{
    public class SingletonServiceLocator : DesignPattern, IDesignPattern
    {
        public static StaticLocator Instance
        {
            get
            {
                StaticLocator locator = StaticLocator.Instance;
                locator.GetService<DatabaseC>().Save();
                locator.GetService<DatabaseD>().Save();
                return locator;
            }
        }
    }
    public class StaticLocator
    {
        private static StaticLocator staticLocator;
        private Dictionary<Type, ISingletonServiceLocator> servicecontainer = null;
        public static StaticLocator Instance
        {
            get
            {
                if (staticLocator == null)
                {
                    staticLocator = new StaticLocator();
                    staticLocator.servicecontainer = new Dictionary<Type, ISingletonServiceLocator>();
                    staticLocator.servicecontainer.Add(typeof(DatabaseC), new DatabaseC());
                    staticLocator.servicecontainer.Add(typeof(DatabaseD), new DatabaseD());
                }
                return staticLocator;
            }
        }
        public T GetService<T>()
        {
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Service not available.");
            }
        }
    }

    public interface ISingletonServiceLocator
    {
        void Save();
    }

    public class DatabaseC : ISingletonServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in C");
        }
    }
    public class DatabaseD : ISingletonServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in D");
        }
    }
}
