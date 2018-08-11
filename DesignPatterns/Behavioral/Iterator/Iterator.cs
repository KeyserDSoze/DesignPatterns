using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator
{
    public class Iterator : DesignPattern, IDesignPattern
    {
        public static Iterator Instance
        {
            get
            {
                IItem rightWeapon = new Weapon() { Label = "Ice Sword" };
                IItem leftWeapon = new Weapon() { Label = "Fire Sword" };
                IItem armor = new Armor() { Label = "Hardrockmail" };
                List<IItem> bag = new List<IItem>();
                bag.Add(new Potion() { Label = "Mana" });
                bag.Add(new Armor() { Label = "Blackmail" });
                bag.Add(new Potion() { Label = "Life" });
                bag.Add(new Weapon() { Label = "Hard Axe" });
                bag.Add(new Potion() { Label = "Mana" });
                bag.Add(new Armor() { Label = "Platemail" });
                bag.Add(new Weapon() { Label = "Light Sword" });
                Inventory inventory = new Inventory(rightWeapon, leftWeapon, armor, bag);
                IInventoryIterator inventoryIterator = inventory.GetIterator();
                while (inventoryIterator.HasItem())
                {
                    Console.WriteLine(inventoryIterator.Current().ToString());
                    inventoryIterator.Next();
                }
                return null;
            }
        }
    }
    public interface IInventory
    {
        IInventoryIterator GetIterator();
    }
    public interface IInventoryIterator
    {
        bool HasItem(); //IsDone in any case
        void Next();
        IItem Current();

    }
    public interface IItem
    {
        string Label { get; set; }
    }
    public class Weapon : IItem
    {
        public int Damage { get; set; } = 1;
        public string Label { get; set; }
        public override string ToString()
        {
            return this.Label + ": increase damage for " + this.Damage.ToString() + " points";
        }
    }
    public class Armor : IItem
    {
        public int Defense { get; set; } = 3;
        public string Label { get; set; }
        public override string ToString()
        {
            return this.Label + ": increase defense for " + this.Defense.ToString() + " points";
        }
    }
    public class Potion : IItem
    {
        public int Hp { get; set; } = 2;
        public string Label { get; set; }
        public override string ToString()
        {
            return "Potion of " + this.Label + ": " + this.Hp.ToString();
        }
    }
    public class Inventory : IInventory
    {
        public IItem Right { get; private set; }
        public IItem Left { get; private set; }
        public IItem Body { get; private set; }
        public List<IItem> Bag { get; private set; }
        public Inventory(IItem right, IItem left, IItem body, List<IItem> bag)
        {
            this.Right = right;
            this.Left = left;
            this.Body = body;
            this.Bag = bag;
        }
        public IInventoryIterator GetIterator()
        {
            return new InventoryIterator(this);
        }
    }
    public class InventoryIterator : IInventoryIterator
    {
        private Inventory Inventory;
        private int index = 0;
        private int Count { get { return this.Inventory.Bag.Count + 3; } }
        public InventoryIterator(Inventory inventory)
        {
            this.Inventory = inventory;
        }
        public bool HasItem()
        {
            return this.index < this.Count;
        }
        public void Next()
        {
            this.index++;
        }
        public IItem First()
        {
            return this.Inventory.Right;
        }
        public IItem Current()
        {
            switch (this.index)
            {
                case 0: return this.Inventory.Right;
                case 1: return this.Inventory.Left;
                case 2: return this.Inventory.Body;
                default:
                    if (this.index >= 3 && this.index < this.Count)
                    {
                        return this.Inventory.Bag[this.index - 3];
                    }
                    else
                    {
                        return null;
                    }
            }
        }
    }
}
