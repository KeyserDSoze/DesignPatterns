using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    public class Strategy : DesignPattern, IDesignPattern
    {
        public static Strategy Instance
        {
            get
            {
                Client client = new Client(new NormalBehavior());
                client.Run();
                Client superClient = new Client(new SuperBehavior());
                client.Run();
                return null;
            }
        }
    }
    public interface IBehavior
    {
        void DoSomething();
    }
    public class NormalBehavior : IBehavior
    {
        public void DoSomething()
        {
            Console.WriteLine("Normal");
        }
    }
    public class SuperBehavior : IBehavior
    {
        public void DoSomething()
        {
            Console.WriteLine("Super");
        }
    }
    public class Client
    {
        public IBehavior Behavior;
        public Client(IBehavior behavior)
        {
            this.Behavior = behavior;
        }

        public void Run()
        {
            this.Behavior.DoSomething();
        }
    }
    //public class Client: IBehavior
    //{
    //    public IBehavior Behavior;
    //    public Client(IBehavior behavior)
    //    {
    //        this.Behavior = behavior;
    //    }

    //    public void DoSomething()
    //    {
    //        this.Behavior.DoSomething();
    //    }
    //}
}
