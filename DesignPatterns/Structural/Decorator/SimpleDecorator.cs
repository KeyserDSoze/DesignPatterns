using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator
{
    public class SimpleDecorator : DesignPattern, IDesignPattern
    {
        public static SimpleDecorator Instance
        {
            get
            {
                IIceCream iceCream = new SourCream(new SourCream(new Chocolate()));
                Console.WriteLine("The cost of an IcreCream with Chocolate and double portion of Sour Cream is: " + iceCream.Cost().ToString());
                iceCream = new SourCream(new Cream());
                Console.WriteLine("The cost of an IcreCream with Cream and a portion of Sour Cream is: " + iceCream.Cost().ToString());
                return null;
            }
        }
    }
    public interface IIceCream
    {
        int Cost();
    }
    public class Chocolate : IIceCream
    {
        public int Cost()
        {
            return 2;
        }
    }
    public class Cream : IIceCream
    {
        public int Cost()
        {
            return 1;
        }
    }
    //decorator
    public interface IDecoratorIceCream : IIceCream
    {
        //put another method if you need
    }
    //Implementation of Decorator
    public class SourCream : IDecoratorIceCream
    {
        private IIceCream iceCream;
        public SourCream(IIceCream iceCream)
        {
            this.iceCream = iceCream;
        }
        public int Cost()
        {
            return 1 + this.iceCream.Cost();
        }
    }
}
