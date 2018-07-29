using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator
{
    public class AbstractDecorator:DesignPattern, IDesignPattern
    {
        public static AbstractDecorator Instance
        {
            get
            {
                Sushi sushi = new Mayonnaise(new Wasabi(new Nigiri()));
                Console.WriteLine(sushi.Description() + " at Euro " + sushi.GetPrice().ToString());
                sushi = new Mayonnaise(new Wasabi(new Spicy(new Maki())));
                Console.WriteLine(sushi.Description() + " at Euro " + sushi.GetPrice().ToString());
                return null;
            }
        }
    }
    public abstract class Sushi
    {
        public abstract int GetPrice();
        public abstract string Description();
    }
    public class Nigiri : Sushi
    {
        public override string Description()
        {
            return "A topping, usually fish, served on top of sushi rice";
        }

        public override int GetPrice()
        {
            return 2;
        }
    }
    public class Maki : Sushi
    {
        public override string Description()
        {
            return "Rice and filling wrapped in seaweed";
        }

        public override int GetPrice()
        {
            return 1;
        }
    }
    //decorator of Sushi
    public class AddictiveIngredient : Sushi
    {
        public Sushi sushi;
        public AddictiveIngredient(Sushi sushi)
        {
            this.sushi = sushi;
        }
        public override string Description()
        {
            return sushi.Description();
        }

        public override int GetPrice()
        {
            return sushi.GetPrice();
        }
    }
    public class Spicy : AddictiveIngredient
    {
        public Spicy(Sushi sushi) : base(sushi) { }
        public override string Description()
        {
            return this.sushi.Description() + " with Spicy";
        }

        public override int GetPrice()
        {
            return this.sushi.GetPrice() + 1;
        }
    }
    public class Mayonnaise : AddictiveIngredient
    {
        public Mayonnaise(Sushi sushi) : base(sushi) { }
        public override string Description()
        {
            return this.sushi.Description() + " with Mayonnaise";
        }

        public override int GetPrice()
        {
            return this.sushi.GetPrice() + 1;
        }
    }
    public class Wasabi : AddictiveIngredient
    {
        public Wasabi(Sushi sushi) : base(sushi) { }
        public override string Description()
        {
            return this.sushi.Description() + " with Wasabi";
        }

        public override int GetPrice()
        {
            return this.sushi.GetPrice() + 2;
        }
    }
}
