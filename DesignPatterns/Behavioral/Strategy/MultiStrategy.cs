using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.MultiStrategy
{
    public class MultiStrategy : DesignPattern, IDesignPattern
    {
        public static MultiStrategy Instance
        {
            get
            {
                Cat normalCat = new Cat(new SmallJump(), new NormaEat(), new NormalMeow());
                normalCat.Show();
                Cat superCat = new Cat(new BigJump(), new NormaEat(), new Roar());
                superCat.Show();
                return null;
            }
        }
    }
    public interface IJumping
    {
        void Jump();
    }
    public interface IMeowing
    {
        void Meow();
    }
    public interface IEating
    {
        void Eat();
    }
    public class SmallJump : IJumping
    {
        public void Jump()
        {
            Console.WriteLine("Small Jump");
        }
    }
    public class BigJump : IJumping
    {
        public void Jump()
        {
            Console.WriteLine("Big Jump");
        }
    }
    public class NormalMeow : IMeowing
    {
        public void Meow()
        {
            Console.WriteLine("Normal Meow");
        }
    }
    public class Roar : IMeowing
    {
        public void Meow()
        {
            Console.WriteLine("Roar");
        }
    }
    public class NormaEat : IEating
    {
        public void Eat()
        {
            Console.WriteLine("Normal Eat");
        }
    }
    public class Cat
    {
        public IJumping Jumping;
        public IEating Eating;
        public IMeowing Meowing;
        public Cat(IJumping jumping, IEating eating, IMeowing meowing)
        {
            this.Jumping = jumping;
            this.Eating = eating;
            this.Meowing = meowing;
        }
        public void Show()
        {
            this.Jumping.Jump();
            this.Eating.Eat();
            this.Meowing.Meow();
        }
    }
}
