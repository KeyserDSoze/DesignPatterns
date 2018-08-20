using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder
{
    public class RealBuilder : DesignPattern, IDesignPattern
    {
        public static RealBuilder Instance
        {
            get
            {
                Console.WriteLine("AirLiner");
                Console.WriteLine(AirPlaneDirector.ConstructAirLiner(2, 1, "White").ToString());
                Console.WriteLine("AirFighter");
                Console.WriteLine(AirPlaneDirector.ConstructAirFighter(4, 4, 2, "Black").ToString());
                return null;
            }
        }
    }
    public class AirPlaneDirector
    {
        public static AirPlane ConstructAirLiner(int numberOfWings, int numberOfEngines, string color)
        {
            IAirPlaneBuilder airPlaneBuilder = new AirLinerBuilder();
            airPlaneBuilder.BuildAirEngine(numberOfEngines);
            airPlaneBuilder.BuildAirChassis(color);
            airPlaneBuilder.BuildWings(numberOfWings);
            airPlaneBuilder.Weapon(0);
            return airPlaneBuilder.airPlane;
        }
        public static AirPlane ConstructAirFighter(int numberOfWings, int numberOfEngines, int numberOfWeapons, string color)
        {
            IAirPlaneBuilder airPlaneBuilder = new AirFighterBuilder();
            airPlaneBuilder.BuildAirEngine(numberOfEngines);
            airPlaneBuilder.BuildAirChassis(color);
            airPlaneBuilder.BuildWings(numberOfWings);
            airPlaneBuilder.Weapon(numberOfWeapons);
            return airPlaneBuilder.airPlane;
        }
    }
    public interface IAirPlaneBuilder
    {
        AirPlane airPlane { get; set; }
        void BuildWings(int number);
        void BuildAirEngine(int number);
        void BuildAirChassis(string color);
        void Weapon(int number);
    }
    public class AirFighterBuilder : IAirPlaneBuilder
    {
        public AirPlane airPlane { get; set; } = new AirPlane();

        public void BuildAirChassis(string color)
        {
            this.airPlane.Color = color;
        }

        public void BuildAirEngine(int number)
        {
            this.airPlane.NumberOfEngines = number;
        }

        public void BuildWings(int number)
        {
            this.airPlane.NumberOfWings = number;
        }

        public void Weapon(int number)
        {
            if (number <= 0) Console.WriteLine("It's not possible to fight without weapons.");
            this.airPlane.NumberOfWeapons = number;
        }
    }
    public class AirLinerBuilder : IAirPlaneBuilder
    {
        public AirPlane airPlane { get; set; } = new AirPlane();

        public void BuildAirChassis(string color)
        {
            this.airPlane.Color = color;
        }

        public void BuildAirEngine(int number)
        {
            this.airPlane.NumberOfEngines = number;
        }

        public void BuildWings(int number)
        {
            this.airPlane.NumberOfWings = number;
        }

        public void Weapon(int number)
        {
            this.airPlane.NumberOfWeapons = number;
        }
    }
    public class AirPlane
    {
        public int NumberOfWings { get; set; }
        public int NumberOfWeapons { get; set; }
        public int NumberOfEngines { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"This airplane has {this.NumberOfWings} wings, {this.NumberOfEngines} engines, {this.NumberOfWeapons} weapons, and it's {this.Color}.";
        }
    }
}
