using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Prototype
{
    public class PrototypeWithICloneable : DesignPattern, IDesignPattern
    {
        public static Hero Instance
        {
            get
            {
                Hero hero = new Hero() { Armor = 1, Damage = 1, Health = 1, Position = new Position() { X = 1, Y = 1 } };
                Console.WriteLine("first creation of an hero: " + hero.ToString());
                Hero shallowCopy = hero.ShallowClone();
                shallowCopy.Position.X = 2;
                shallowCopy.Position.Y = 3;
                Console.WriteLine("shallow copy of an hero with changed position: " + shallowCopy.ToString());
                Console.WriteLine("first created hero with position changed due the changing in his shallow copy: " + hero.ToString());
                hero = new Hero() { Armor = 1, Damage = 1, Health = 1, Position = new Position() { X = 1, Y = 1 } };
                Hero deepCopy = (Hero)hero.Clone();
                deepCopy.Position.X = 2;
                deepCopy.Position.Y = 4;
                Console.WriteLine("deep copy of an hero with changed position: " + shallowCopy.ToString());
                Console.WriteLine("first created hero without position changed despite the changing in his deep copy: " + hero.ToString());
                return hero;
            }
        }
    }

    public class Hero : ICloneable
    {
        private int health;
        private int damage;
        private int armor;
        private Position position;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }
        private Hero ShallowCopy()
        {
            return this.MemberwiseClone() as Hero;
        }

        private Hero DeepCopy()
        {
            Hero cloned = this.ShallowCopy();
            cloned.Position = new Position();
            cloned.Position.X = this.Position.X;
            cloned.Position.Y = this.Position.Y;
            return cloned;
        }
        public object Clone()
        {
            return this.DeepCopy();
        }
        //created only to understand the meaning of shallow and deep copy
        public Hero ShallowClone()
        {
            return this.ShallowCopy();
        }
        public override string ToString()
        {
            return string.Format("Hero with Health: {0}, Damage: {1}, Armor: {2}, in Position {3}-{4}", this.Health, this.Damage, this.Armor, this.Position.X, this.Position.Y);
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
