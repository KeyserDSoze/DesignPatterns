using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder
{
    public class Builder: DesignPattern, IDesignPattern
    {
        public static Car Instance
        {
            get
            {
                Car car = CarBuilder.CreateCar(180, 110);
                Console.WriteLine(car.ToString());
                return car;
            }
        }
    }
    public class Car
    {
        private Wheel[] _wheels;
        private Engine _engine;
        private Chassis _chassis;

        public Wheel Wheel1
        {
            set { _wheels[0] = value; }
            get { return _wheels[0]; }
        }

        public Wheel Wheel2
        {
            set { _wheels[1] = value; }
            get { return _wheels[1]; }
        }

        public Wheel Wheel3
        {
            set { _wheels[2] = value; }
            get { return _wheels[2]; }
        }

        public Wheel Wheel4
        {
            set { _wheels[3] = value; }
            get { return _wheels[3]; }
        }

        public Engine Engine
        {
            set { _engine = value; }
            get { return _engine; }
        }

        public Chassis Chassis
        {
            set { _chassis = value; }
            get { return _chassis; }
        }

        public Car()
        {
            _wheels = new Wheel[4];
        }

        public override string ToString()
        {
            return _wheels[0].ToString() + " / " +
                   _wheels[1].ToString() + " / " +
                   _wheels[2].ToString() + " / " +
                   _wheels[3].ToString() + " / " +
                   _engine.ToString() + " / " + _chassis.ToString();
        }
    }

    public class Wheel
    {
        private double _size;

        public Wheel(double size) { _size = size; }

        public override string ToString()
        {
            return "Wheel " + _size.ToString();
        }
    }

    public class Engine
    {
        private double _power;

        public Engine(double power) { _power = power; }

        public override string ToString()
        {
            return "Engine " + _power.ToString();
        }
    }

    public class Chassis
    {
        public Chassis() { }

        public override string ToString()
        {
            return "Chassis";
        }
    }

    public class CarBuilder
    {
        public static Car CreateCar(double wheelSize, double enginePower)
        {
            Car c = new Car();
            c.Wheel1 = new Wheel(wheelSize);
            c.Wheel2 = new Wheel(wheelSize);
            c.Wheel3 = new Wheel(wheelSize);
            c.Wheel4 = new Wheel(wheelSize);
            c.Engine = new Engine(enginePower);
            c.Chassis = new Chassis();
            return c;
        }
    }
}
