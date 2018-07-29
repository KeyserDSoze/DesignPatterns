using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class Multiton : DesignPattern, IDesignPattern, ITwoAttempts
    {
        private static Dictionary<string, Multiton> instances = new Dictionary<string, Multiton>();
        private Multiton()
        {
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        public static Multiton Instance(string Key = "Test")
        {
            if (instances == null)
            {
                instances = new Dictionary<string, Multiton>();
            }
            if (!instances.ContainsKey(Key))
            {
                instances.Add(Key, new Multiton());
            }
            Console.WriteLine("Get Instance");
            return instances[Key];
        }
    }
}
