using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class NormalSingleton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private static NormalSingleton instance = null;
        private NormalSingleton()
        {
            Console.WriteLine("instance of an object "+ this.GetMyName());
        }
        public static NormalSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NormalSingleton();
                }
                Console.WriteLine("Get Instance");
                return instance;
            }
        }
    }
}
