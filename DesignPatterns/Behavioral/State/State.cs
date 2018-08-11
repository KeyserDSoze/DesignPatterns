using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.State
{
    public class State : DesignPattern, IDesignPattern
    {
        public static State Instance
        {
            get
            {
                Gate gate = new Gate();
                Console.WriteLine("I try to enter");
                gate.Enter();
                Console.WriteLine(gate.CurrentStatus);
                Console.WriteLine("If you don't pay you cannot pass through me.");
                Console.WriteLine("I try to pay");
                gate.Pay();
                Console.WriteLine(gate.CurrentStatus);
                Console.WriteLine("Payment failed");
                gate.PayFail();
                Console.WriteLine(gate.CurrentStatus);
                Console.WriteLine("I try to enter");
                gate.Enter();
                Console.WriteLine(gate.CurrentStatus);
                Console.WriteLine("If payment doesn't work you cannot pass through me.");
                Console.WriteLine("I try to pay");
                gate.Pay();
                Console.WriteLine(gate.CurrentStatus);
                Console.WriteLine("Payment is ok");
                gate.PayOk();
                Console.WriteLine(gate.CurrentStatus);
                Console.WriteLine("I try to enter and now it works, after my entrance");
                gate.Enter();
                Console.WriteLine(gate.CurrentStatus);
                Console.WriteLine("Finally you must do your duty.");
                return null;
            }
        }
    }
    public class Gate
    {
        private IGateState gateState = new CloseGateState();
        public string CurrentStatus { get { return "Current Status: " + this.gateState.ToString(); } }
        public void Pay()
        {
            this.gateState = gateState.Pay();
        }
        public void PayOk()
        {
            this.gateState = gateState.PayOk();
        }
        public void PayFail()
        {
            this.gateState = gateState.PayFail();
        }
        public void Enter()
        {
            this.gateState = gateState.Enter();
        }
    }
    public interface IGateState
    {
        IGateState Pay();
        IGateState PayOk();
        IGateState PayFail();
        IGateState Enter();
    }
    public class CloseGateState : IGateState
    {
        public IGateState Enter()
        {
            return new CloseGateState();
        }

        public IGateState Pay()
        {
            return new ProcessPayGateState();
        }

        public IGateState PayFail()
        {
            return new CloseGateState();
        }

        public IGateState PayOk()
        {
            return new OpenGateState();
        }
        public override string ToString()
        {
            return "Closed";
        }
    }
    public class ProcessPayGateState : IGateState
    {
        public IGateState Enter()
        {
            return new CloseGateState();
        }

        public IGateState Pay()
        {
            return new ProcessPayGateState();
        }

        public IGateState PayFail()
        {
            return new CloseGateState();
        }

        public IGateState PayOk()
        {
            return new OpenGateState();
        }
        public override string ToString()
        {
            return "Processing Payment";
        }
    }
    public class OpenGateState : IGateState
    {
        public IGateState Enter()
        {
            return new CloseGateState();
        }

        public IGateState Pay()
        {
            return new OpenGateState();
        }

        public IGateState PayFail()
        {
            return new OpenGateState();
        }

        public IGateState PayOk()
        {
            return new OpenGateState();
        }
        public override string ToString()
        {
            return "Open";
        }
    }
}
