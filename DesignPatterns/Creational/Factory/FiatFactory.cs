using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory
{
    public class FiatFactory : DesignPattern, IDesignPattern
    {
        public static FiatFactory Instance
        {
            get
            {
                Console.WriteLine("First production line");
                ProductionLine1 productionLine1 = new ProductionLine1();
                Console.WriteLine(string.Join('\n'.ToString(), productionLine1.fiatCars));
                Console.WriteLine("Second production line");
                ProductionLine2 productionLine2 = new ProductionLine2();
                Console.WriteLine(string.Join('\n'.ToString(), productionLine2.fiatCars));
                return null;
            }
        }
    }
    public abstract class Fiat
    {
        public int WheelNumber { get; set; }
        public string Color { get; set; }
        public string Label { get; set; }
        public override string ToString()
        {
            return $"Fiat-{this.Label} with {this.WheelNumber} wheels and color {this.Color}";
        }
    }
    public class Panda : Fiat
    {
        public Panda()
        {
            this.Color = "red";
            this.WheelNumber = 4;
            this.Label = "Panda";
        }
    }
    public class Uno : Fiat
    {
        public Uno()
        {
            this.Color = "green";
            this.WheelNumber = 4;
            this.Label = "Uno";
        }
    }
    public abstract class ProductionLine
    {
        public List<Fiat> fiatCars = new List<Fiat>();
        public ProductionLine()
        {
            this.CreateProductionLine();
        }
        public abstract void CreateProductionLine();
    }
    public class ProductionLine1 : ProductionLine
    {
        public override void CreateProductionLine()
        {
            this.fiatCars = new List<Fiat>();
            this.fiatCars.Add(new Panda());
            this.fiatCars.Add(new Panda());
            this.fiatCars.Add(new Uno());
            this.fiatCars.Add(new Uno());
            this.fiatCars.Add(new Panda());
        }
    }
    public class ProductionLine2 : ProductionLine
    {
        public override void CreateProductionLine()
        {
            this.fiatCars = new List<Fiat>();
            this.fiatCars.Add(new Uno());
            this.fiatCars.Add(new Uno());
        }
    }
}
