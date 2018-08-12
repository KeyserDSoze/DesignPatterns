using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.NullObject
{
    public class NullObject : DesignPattern, IDesignPattern
    {
        public static NullObject Instance
        {
            get
            {
                Track track = new Track();
                Console.WriteLine("Get first when cars are not on the track");
                Console.WriteLine("First has speed of: " + track.First().Speed); //client doesn't need to check if first is null
                track.Cars.Add(new Car());
                track.Cars.Add(new Car());
                Console.WriteLine("Get first when cars are on the track");
                Console.WriteLine("First has speed of: " + track.First().Speed);
                return null;
            }
        }
    }
    public class Track
    {
        public List<ICar> Cars { get; set; } = new List<ICar>();
        public ICar First()
        {
            return this.Cars.Count > 0 ? this.Cars[0] : new NullCar();
        }
    }
    public interface ICar
    {
        double Speed { get; set; }
        double Acceleration { get; set; }
    }
    public class Car : ICar
    {
        public double Speed { get; set; } = 200;
        public double Acceleration { get; set; } = 10;
    }
    public class NullCar : ICar
    {
        public double Speed { get; set; } = 0;
        public double Acceleration { get; set; } = 0;
    }
}
