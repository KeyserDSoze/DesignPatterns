using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class NormalSingleton : IDesignPattern
    {
        private static NormalSingleton instance = null;
        private NormalSingleton()
        {
        }
        public static NormalSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NormalSingleton();
                }
                return instance;
            }
        }
    }
}
