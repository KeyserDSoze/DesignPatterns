using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.ServiceLocator
{
    public class IoCServiceLocator : DesignPattern, IDesignPattern
    {
        public static IoCServiceLocator Instance
        {
            get
            {
                IocLocator iocLocator = new IocLocator(true);
                Console.WriteLine("In first implementation i use the older database");
                iocLocator.Save();
                iocLocator = new IocLocator(false);
                Console.WriteLine("When i must switch the DB i only need to switch the dependency in the service locator constructor");
                iocLocator.Save();
                return null;
            }
        }
    }
    public class IocLocator
    {
        private IIoCServiceLocator ioCServiceLocator;
        public IocLocator(bool oldest)
        {
            if (oldest) ioCServiceLocator = new FirstDatabase(); else ioCServiceLocator = new NewDatabase();
        }
        public void Save()
        {
            this.ioCServiceLocator.Save();
        }
    }
    public interface IIoCServiceLocator
    {
        void Save();
    }
    public class FirstDatabase : IIoCServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in first database created");
        }
    }
    public class NewDatabase : IIoCServiceLocator
    {
        public void Save()
        {
            Console.WriteLine("Save in New Database");
        }
    }
}
