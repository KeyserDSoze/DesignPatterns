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
                Client client = new Client(new Cat()); //dependency injection of cat
                client.WhoAreYou();
                Client client2 = new Client(new Dog()); //dependency injection of dog
                client2.WhoAreYou();
                return null;
            }
        }
    }
    public class Client
    {
        private IAnimal animal;
        public Client(IAnimal animal)
        {
            this.animal = animal;
        }
        public void WhoAreYou()
        {
            this.animal.SayWhatIAm();
        }
    }
    public interface IAnimal
    {
        void SayWhatIAm();
    }
    public class Cat : IAnimal
    {
        public void SayWhatIAm()
        {
            Console.WriteLine("I'm a cat");
        }
    }
    public class Dog : IAnimal
    {
        public void SayWhatIAm()
        {
            Console.WriteLine("I'm a dog");
        }
    }
}
