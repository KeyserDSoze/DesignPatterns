using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class OperationalSingleton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private static OperationalSingleton instance = null;
        private static int numberOfOperation = 0;
        private const int refreshedOperation = 100;
        private OperationalSingleton()
        {
            numberOfOperation = 0;
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        public static OperationalSingleton Instance
        {
            get
            {
                Interlocked.Add(ref numberOfOperation, 1);
                if (instance == null || numberOfOperation > refreshedOperation)
                {
                    instance = new OperationalSingleton();
                }
                Console.WriteLine("Get Instance");
                return instance;
            }
        }
    }
}
