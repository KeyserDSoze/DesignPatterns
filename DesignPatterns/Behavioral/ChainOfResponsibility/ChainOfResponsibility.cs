using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class ChainOfResponsibility : DesignPattern, IDesignPattern
    {
        public static ChainOfResponsibility Instance
        {
            get
            {
                //here we're creating the chain for our special case
                ISubscriptionEvent activation = new Activation();
                ISubscriptionEvent message = new Message();
                ISubscriptionEvent billing = new Billing();
                activation.SetNextSubscriptionEvent(message);
                message.SetNextSubscriptionEvent(billing);

                //and here we execute the chain
                CustomerBase customerBase = new CustomerBase(activation) { UserId = "KeyserDSoze" };
                Console.WriteLine(customerBase.ToString());
                //usually it's started from the first chain, but i want to make a more efficient starting
                //with dependecy injection in customerbase constructor we decide what starts the chain
                customerBase.Execute();
                Console.WriteLine(customerBase.ToString());
                customerBase.Execute();
                Console.WriteLine(customerBase.ToString());
                customerBase.Execute();
                Console.WriteLine(customerBase.ToString());

                return null;
            }
        }
    }
    public class CustomerBase
    {
        public string UserId { get; set; }
        public bool IsActive { get; set; } = false;
        public bool InformativeMessageIsSent { get; set; } = false;
        public double Billed { get; set; } = 0;
        private ISubscriptionEvent startEvent;
        public CustomerBase(ISubscriptionEvent startEvent)
        {
            this.startEvent = startEvent;
        }
        public void Execute()
        {
            this.startEvent.Execute(this);
        }
        public override string ToString()
        {
            return $"User: {this.UserId} is active: {this.IsActive}, the system sent informative message: {this.InformativeMessageIsSent} and is billed for {this.Billed}";
        }
    }
    public interface ISubscriptionEvent  //chain
    {
        void SetNextSubscriptionEvent(ISubscriptionEvent subscriptionEvent);
        void Execute(CustomerBase customerBase);
    }
    public class Activation : ISubscriptionEvent
    {
        private ISubscriptionEvent nextSubscriptionEvent;
        public void Execute(CustomerBase customerBase)
        {
            if (!customerBase.IsActive)
            {
                customerBase.IsActive = true;
            }
            else
            {
                //it's possible to implement a check, for example go on next one only if the user is active in this case
                this.nextSubscriptionEvent.Execute(customerBase);
            }
        }

        public void SetNextSubscriptionEvent(ISubscriptionEvent subscriptionEvent)
        {
            this.nextSubscriptionEvent = subscriptionEvent;
        }
    }
    public class Message : ISubscriptionEvent
    {
        private ISubscriptionEvent nextSubscriptionEvent;
        public void Execute(CustomerBase customerBase)
        {
            if (!customerBase.InformativeMessageIsSent)
            {
                customerBase.InformativeMessageIsSent = true;
            }
            else
            {
                this.nextSubscriptionEvent.Execute(customerBase);
            }
        }

        public void SetNextSubscriptionEvent(ISubscriptionEvent subscriptionEvent)
        {
            this.nextSubscriptionEvent = subscriptionEvent;
        }
    }
    public class Billing : ISubscriptionEvent
    {
        private ISubscriptionEvent nextSubscriptionEvent;
        public void Execute(CustomerBase customerBase)
        {
            if (customerBase.Billed <= 0)
            {
                customerBase.Billed = 6;
            }
            else
            {
                this.nextSubscriptionEvent.Execute(customerBase);
            }
        }

        public void SetNextSubscriptionEvent(ISubscriptionEvent subscriptionEvent)
        {
            this.nextSubscriptionEvent = subscriptionEvent;
        }
    }
}
