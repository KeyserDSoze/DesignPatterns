using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class DoubleCheckThreadSafeSingleton : DesignPattern, IDesignPattern
    {
        private static DoubleCheckThreadSafeSingleton instance = null;
        private static readonly object trafficlight = new object();
        private DoubleCheckThreadSafeSingleton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        public static DoubleCheckThreadSafeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (trafficlight)
                    {
                        if (instance == null)
                        {
                            instance = new DoubleCheckThreadSafeSingleton();
                        }
                    }
                }
                Console.WriteLine("Get Instance");
                return instance;
            }
        }
    }
}
