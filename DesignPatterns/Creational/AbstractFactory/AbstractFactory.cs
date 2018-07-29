using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class AbstractFactory : DesignPattern, IDesignPattern
    {
        public static IShape Instance
        {
            get
            {
                IShapeFactory fac = new MyShapeFactory();
                Circle c = fac.CreateCircle();
                Rectangle r = fac.CreateRectangle();
                c.Print();
                r.Print();
                return null;
            }
        }
    }
    public interface IShape
    {
        void Print();
    }

    public class Rectangle : IShape
    {
        public virtual void Print()
        {
            Console.WriteLine("Rectangle");
        }
    }

    public class Circle : IShape
    {
        public virtual void Print()
        {
            Console.WriteLine("Circle");
        }
    }

    public interface IShapeFactory
    {
        Rectangle CreateRectangle();
        Circle CreateCircle();
    }

    public class MyRectangle : Rectangle
    {
        public override void Print()
        {
            Console.WriteLine("MyRectangle");
        }
    }

    public class MyCircle : Circle
    {
        public override void Print()
        {
            Console.WriteLine("MyCircle");
        }
    }

    public class MyShapeFactory : IShapeFactory
    {
        public Rectangle CreateRectangle()
        {
            return new MyRectangle();
        }

        public Circle CreateCircle()
        {
            return new MyCircle();
        }
    }
}
