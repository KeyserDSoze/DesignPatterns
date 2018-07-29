using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory
{
    public enum ShapeType
    {
        Rectangle = 1,
        Circle = 2
    }

    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }

    public class ShapeCreator
    {
        private static ShapeCreator _instance = new ShapeCreator();

        public static ShapeCreator Instance
        {
            get { return _instance; }
        }

        public Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Circle:
                    return new Circle();
                default:
                    throw new ArgumentException("type");
            }
        }
    }

    public class Factory : DesignPattern, IDesignPattern
    {
        public static Shape[] Instance
        {
            get
            {
                Shape[] shapes =
            new Shape[] { ShapeCreator.Instance.CreateShape(ShapeType.Circle),
                          ShapeCreator.Instance.CreateShape(ShapeType.Rectangle) };
                foreach (Shape s in shapes)
                    s.Draw();
                return shapes;
            }
        }
    }
}
