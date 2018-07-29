using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Prototype
{
    public class SimplePrototype : DesignPattern, IDesignPattern
    {
        public static TrueHero Instance
        {
            get
            {
                TrueHero hero = new TrueHero() { Armor = 1, Damage = 1, Health = 1, Position = new BasePosition() { X = 1, Y = 1 } };
                Console.WriteLine("first creation of an hero: " + hero.ToString());
                BaseHero shallowCopy = hero.ShallowClone();
                shallowCopy.Position.X = 2;
                shallowCopy.Position.Y = 3;
                Console.WriteLine("shallow copy of an hero with changed position: " + shallowCopy.ToString());
                Console.WriteLine("first created hero with position changed due the changing in his shallow copy: " + hero.ToString());
                hero = new TrueHero() { Armor = 1, Damage = 1, Health = 1, Position = new BasePosition() { X = 1, Y = 1 } };
                BaseHero deepCopy = hero.Clone();
                deepCopy.Position.X = 2;
                deepCopy.Position.Y = 4;
                Console.WriteLine("deep copy of an hero with changed position: " + shallowCopy.ToString());
                Console.WriteLine("first created hero without position changed despite the changing in his deep copy: " + hero.ToString());
                return hero;
            }
        }
    }

    public abstract class BaseHero
    {
        private int health;
        private int damage;
        private int armor;
        private BasePosition position;

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
        public BasePosition Position
        {
            get { return position; }
            set { position = value; }
        }
        public abstract BaseHero Clone();
        public override string ToString()
        {
            return string.Format("Hero with Health: {0}, Damage: {1}, Armor: {2}, in Position {3}-{4}", this.Health, this.Damage, this.Armor, this.Position.X, this.Position.Y);
        }
    }
    public class BasePosition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class TrueHero : BaseHero
    {
        private BaseHero ShallowCopy()
        {
            return this.MemberwiseClone() as BaseHero;
        }

        private BaseHero DeepCopy()
        {
            BaseHero cloned = this.MemberwiseClone() as BaseHero;
            cloned.Position = new BasePosition();
            cloned.Position.X = this.Position.X;
            cloned.Position.Y = this.Position.Y;
            return cloned;
        }
        public override BaseHero Clone()
        {
            return this.DeepCopy();
        }
        public BaseHero ShallowClone()
        {
            return this.ShallowCopy();
        }
    }
}
