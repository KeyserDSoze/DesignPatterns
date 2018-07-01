using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class TimedSingleton : DesignPattern, IDesignPattern
    {
        private static TimedSingleton instance = null;
        private static DateTime LastTime = new DateTime(1970, 1, 1);
        private const int refreshedHours = 1;
        private TimedSingleton()
        {
            LastTime = DateTime.Now;
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        public static TimedSingleton Instance
        {
            get
            {
                if (instance == null || DateTime.Now.Subtract(LastTime).TotalHours > refreshedHours)
                {
                    instance = new TimedSingleton();
                }
                Console.WriteLine("Get Instance");
                return instance;
            }
        }
    }
}
