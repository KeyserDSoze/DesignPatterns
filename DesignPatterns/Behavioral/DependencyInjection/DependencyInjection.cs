using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.DependencyInjection
{
    public class DependencyInjection : DesignPattern, IDesignPattern
    {
        public static DependencyInjection Instance
        {
            get
            {
                Client client = new Client(new Cat(), new Eagle()); //dependency injection of cat
                client.WhoAreYou();
                Client client2 = new Client(new Dog(), new Albatros()); //dependency injection of dog
                client2.WhoAreYou();
                return null;
            }
        }
    }
    public class Client
    {
        private IMammal mammal;
        private Bird bird;
        public Client(IMammal mammal, Bird bird)
        {
            this.mammal = mammal;
            this.bird = bird;
        }
        public void WhoAreYou()
        {
            this.mammal.SayWhatIAm();
            this.bird.SayWhatIAm();
        }
    }
    public interface IMammal
    {
        void SayWhatIAm();
    }
    public class Cat : IMammal
    {
        public void SayWhatIAm()
        {
            Console.WriteLine("I'm a cat");
        }
    }
    public class Dog : IMammal
    {
        public void SayWhatIAm()
        {
            Console.WriteLine("I'm a dog");
        }
    }
    public abstract class Bird
    {
        public void SayWhatIAm()
        {
            Console.WriteLine("I'm a " + this.GetType().Name);
        }
    }
    public class Eagle : Bird
    {

    }
    public class Albatros : Bird
    {

    }
}
