using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ServiceLocator
{
    public class ServiceLocator : DesignPattern, IDesignPattern
    {
        public static Locator Instance
        {
            get
            {
                Locator locator = new Locator();
                locator.GetService<DatabaseA>().Save();
                locator.GetService<DatabaseB>().Save();
                return locator;
            }
        }
    }
    public class Locator
    {
        public Dictionary<Type, IServiceLocator> servicecontainer;
        public Locator()
        {
            servicecontainer = new Dictionary<Type, IServiceLocator>();
            servicecontainer.Add(typeof(DatabaseA), new DatabaseA());
            servicecontainer.Add(typeof(DatabaseB), new DatabaseB());
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

    public interface IServiceLocator
    {
        void Save();
    }

    public class DatabaseA : IServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in A");
        }
    }
    public class DatabaseB : IServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in B");
        }
    }
}
