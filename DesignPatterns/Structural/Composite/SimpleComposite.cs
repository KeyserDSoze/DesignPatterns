using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite
{
    public class SimpleComposite : DesignPattern, IDesignPattern
    {
        public static SimpleComposite Instance
        {
            get
            {
                Composite component = new Composite("Me");
                Composite father = new Composite("Father of Me");
                father.AddChild(new Leaf("GrandFather of Father"));
                father.AddChild(new Leaf("GrandMother of Father"));
                Composite mother = new Composite("Mother of Me");
                mother.AddChild(new Leaf("GrandFather of Mother"));
                mother.AddChild(new Leaf("GrandMother of Mother"));
                component.AddChild(father);
                component.AddChild(mother);
                Console.WriteLine(component.Operation());
                return null;
            }
        }
    }
    public abstract class Component
    {
        public readonly string Name;
        public Component(string name)
        {
            this.Name = name;
        }
        public abstract string Operation();
    }
    public class Composite : Component
    {
        private List<Component> components = new List<Component>();
        public Composite(string name) : base(name) { }
        public void AddChild(Component component)
        {
            this.components.Add(component);
        }
        public void RemoveChild(Component component)
        {
            this.components.Remove(component);
        }
        public override string Operation()
        {
            string result = this.Name;
            foreach(Component component in this.components)
            {
                result += '\n'.ToString() + " has:" + component.Operation();
            }
            return result;
        }
    }
    public class Leaf : Component
    {
        public Leaf(string name) : base(name) { }
        public override string Operation()
        {
            return this.Name;
        }
    }
}
