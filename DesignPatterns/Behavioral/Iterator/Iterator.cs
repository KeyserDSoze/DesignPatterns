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
                IItem rightWeapon = new Weapon();
                IItem leftWeapon = new Weapon();
                IItem armor = new Armor();
                List<IItem> bag = new List<IItem>();
                bag.Add(new Potion());
                bag.Add(new Armor());
                bag.Add(new Potion());
                bag.Add(new Weapon());
                bag.Add(new Potion());
                bag.Add(new Armor());
                bag.Add(new Weapon());
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

    }
    public class Weapon : IItem
    {
        public int Damage { get; set; } = 1;
        public override string ToString()
        {
            return "Increase damage for: " + this.Damage.ToString() + " points";
        }
    }
    public class Armor : IItem
    {
        public int Defense { get; set; } = 3;
        public override string ToString()
        {
            return "Increase defense for: " + this.Defense.ToString() + " points";
        }
    }
    public class Potion : IItem
    {
        public int Hp { get; set; } = 2;
        public override string ToString()
        {
            return "Possible Restored Hp: " + this.Hp.ToString();
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
