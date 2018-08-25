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
                Client client = new Client(new Cat()) { bird = new Eagle() }; //dependency injection of cat
                client.SetDependency(new Turtle());
                client.WhoAreYou();
                Client client2 = new Client(new Dog()) { bird = new Albatros() }; //dependency injection of dog
                client2.SetDependency(new Lizard());
                client2.WhoAreYou();
                return null;
            }
        }
    }
    public class Client
    {
        private IMammal mammal;
        public Bird bird { get; set; }
        private IReptile reptile;
        public Client(IMammal mammal)
        {
            this.mammal = mammal;
        }
        public void SetDependency(IReptile reptile)
        {
            this.reptile = reptile;
        }
        public void WhoAreYou()
        {
            this.mammal.SayWhatIAm();
            this.bird.SayWhatIAm();
            this.reptile.SayWhatIAm();
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
    public interface IReptile
    {
        void SayWhatIAm();
    }
    public class Turtle : IReptile
    {
        public void SayWhatIAm()
        {
            Console.WriteLine("I'm a Turtle");
        }
    }
    public class Lizard : IReptile
    {
        public void SayWhatIAm()
        {
            Console.WriteLine("I'm a Lizard");
        }
    }
}
