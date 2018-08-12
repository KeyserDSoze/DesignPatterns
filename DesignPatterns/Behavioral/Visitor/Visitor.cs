using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Visitor
{
    public class Visitor : DesignPattern, IDesignPattern
    {
        public static Visitor Instance
        {
            get
            {
                BasicNeed basicNeed = new BasicNeed() { Label = "Bread", Price = 2 };
                OtherNeed otherNeed = new OtherNeed() { Label = "Smartphone", Price = 500 };
                double vatItalyNeed = basicNeed.CalculateVAT(new ItalyTax());
                Console.WriteLine(basicNeed.ToString() + vatItalyNeed.ToString() + " in Italy");
                double vatItalyNoNeed = otherNeed.CalculateVAT(new ItalyTax());
                Console.WriteLine(otherNeed.ToString() + vatItalyNoNeed.ToString() + " in Italy");
                double vatEnglandNeed = basicNeed.CalculateVAT(new EnglandTax());
                Console.WriteLine(basicNeed.ToString() + vatEnglandNeed.ToString() + " in England");
                double vatEnglandNoNeed = otherNeed.CalculateVAT(new EnglandTax());
                Console.WriteLine(otherNeed.ToString() + vatEnglandNoNeed.ToString() + " in England");
                return null;
            }
        }
    }
    public interface IVisitor
    {
        double Visit(BasicNeed basicNeed);
        double Visit(OtherNeed otherNeed);
    }
    public class ItalyTax : IVisitor
    {
        public double Visit(BasicNeed basicNeed)
        {
            return basicNeed.Price * 4 / 100;
        }

        public double Visit(OtherNeed otherNeed)
        {
            return otherNeed.Price * 22 / 100;
        }
    }
    public class EnglandTax : IVisitor
    {
        public double Visit(BasicNeed basicNeed)
        {
            return basicNeed.Price * 5 / 100;
        }

        public double Visit(OtherNeed otherNeed)
        {
            return otherNeed.Price * 20 / 100;
        }
    }
    public interface IVisitable
    {
        double CalculateVAT(IVisitor visitor);
    }
    public class BasicNeed : IVisitable
    {
        public string Label { get; set; }
        public double Price { get; set; }
        public double CalculateVAT(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {
            return $"{this.Label} with price {this.Price} has VAT: ";
        }
    }
    public class OtherNeed : IVisitable
    {
        public string Label { get; set; }
        public double Price { get; set; }
        public double CalculateVAT(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
        public override string ToString()
        {
            return $"{this.Label} with price {this.Price} has VAT: ";
        }
    }
}
