using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public class DoubleCheckThreadSafeSingleton : IDesignPattern
    {
        private static DoubleCheckThreadSafeSingleton instance = null;
        private static readonly object trafficlight = new object();
        private DoubleCheckThreadSafeSingleton()
        {
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
                return instance;
            }
        }
    }
}
