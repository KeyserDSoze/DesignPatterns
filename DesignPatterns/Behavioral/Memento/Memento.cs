using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Memento
{
    public class Memento : DesignPattern, IDesignPattern
    {
        public static Memento Instance
        {
            get
            {
                Player player = new Player() { Hp = 2, Armor = 1, Damage = 1 };
                CareTakerOfPlayerMemento careTakerOfPlayerMemento = new CareTakerOfPlayerMemento()
                {
                    MementoOfPlayer = player.SaveStatus()  //we're saving status in caretaker of memento
                };
                Console.WriteLine(player.ToString());
                Console.WriteLine("Using a spell on player that doubles up his Hp");
                player.Hp *= 2;
                Console.WriteLine("new status with spell: " + player.ToString());
                Console.WriteLine("Enemy uses a dispell");
                player.RestoreStatus(careTakerOfPlayerMemento.MementoOfPlayer);
                Console.WriteLine("new status after dispell: " + player.ToString());
                return null;
            }
        }
    }
    public class Player
    {
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public MementoOfPlayer SaveStatus()
        {
            return new MementoOfPlayer() { Armor = this.Armor, Damage = this.Damage, Hp = this.Hp };
        }
        public void RestoreStatus(MementoOfPlayer mementoOfPlayer)
        {
            this.Armor = mementoOfPlayer.Armor;
            this.Damage = mementoOfPlayer.Damage;
            this.Hp = mementoOfPlayer.Hp;
        }
        public override string ToString()
        {
            return $"Player has: {this.Hp} Hp, {this.Damage} Damage and {this.Armor} Armor.";
        }
    }
    public class MementoOfPlayer  //it's a class with properties and field (any information) of the class that we want to save
    {
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }
    public class CareTakerOfPlayerMemento
    {
        public MementoOfPlayer MementoOfPlayer { get; set; }
    }
}
