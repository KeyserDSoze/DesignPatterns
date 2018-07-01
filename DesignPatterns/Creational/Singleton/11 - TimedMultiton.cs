using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public sealed class TimedMultiton : DesignPattern, IDesignPattern
    {
        private static Dictionary<string, TimedMultiton> Instances = new Dictionary<string, TimedMultiton>();
        private TimedMultiton()
        {
            this.LastTime = DateTime.Now;
            Console.WriteLine("instance of an object " + this.GetMyName());
        }
        public static TimedMultiton Instance(string Key = "Test")
        {
            if (Instances == null)
            {
                Instances = new Dictionary<string, TimedMultiton>();
            }
            if (!Instances.ContainsKey(Key) || Instances[Key].Expired)
            {
                Instances.Add(Key, new TimedMultiton());
            }
            Console.WriteLine("Get Instance");
            return Instances[Key];
        }
        private DateTime LastTime = new DateTime(1970, 1, 1);
        private const int refreshedHours = 1;
        private bool Expired { get { return DateTime.Now.Subtract(LastTime).TotalHours > refreshedHours; } }
    }
}
