using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    public class TemplateMethod : DesignPattern, IDesignPattern
    {
        public static TemplateMethod Instance
        {
            get
            {
                AbstractSubscription mySubscription = new MySubscription();
                mySubscription.MakeSubscription();
                AbstractSubscription anotherSubscription = new AnotherSubscription();
                anotherSubscription.MakeSubscriptionWithoutNotification();
                return null;
            }
        }
    }
    public abstract class AbstractSubscription
    {
        public void MakeSubscription()
        {
            this.Activate();
            this.Notify();
            this.Bill();
        }
        public void MakeSubscriptionWithoutNotification()
        {
            this.Activate();
            this.Bill();
        }
        public abstract void Activate();
        public abstract void Notify();
        public abstract void Bill();
    }
    public class MySubscription : AbstractSubscription
    {
        public override void Activate()
        {
            Console.WriteLine("Make Activation");
        }

        public override void Bill()
        {
            Console.WriteLine("Make Billing");
        }

        public override void Notify()
        {
            Console.WriteLine("Send Notification");
        }
    }
    public class AnotherSubscription : AbstractSubscription
    {
        public override void Activate()
        {
            Console.WriteLine("Make another Activation");
        }

        public override void Bill()
        {
            Console.WriteLine("Make another Billing");
        }

        public override void Notify()
        {
            Console.WriteLine("Send another Notification");
        }
    }
}
