using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command
{
    public class Command : DesignPattern, IDesignPattern
    {
        public static Command Instance  //Client
        {
            get
            {
                Client client = new Client();
                client.Compute(100);
                client.Compute(20);
                client.Compute(40);
                client.Undo();
                client.Undo();
                client.Redo();
                client.Compute(100);
                return null;
            }
        }
    }
    public abstract class ACommand  //Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }
    public class Sum : ACommand  //ConcreteCommand
    {
        private CalculatorCpu calculatorCpu;
        private int value;
        public Sum(CalculatorCpu calculatorCpu, int value)
        {
            this.calculatorCpu = calculatorCpu;
            this.value = value;
        }
        public override void Execute()
        {
            this.calculatorCpu.Plus(this.value);
        }
        public override void UnExecute()
        {
            this.calculatorCpu.Minus(this.value);
        }
    }
    public class CalculatorCpu //Receiver
    {
        private int current = 0;
        public void Plus(int value)
        {
            this.current += value;
            Console.WriteLine("value now: " + this.current.ToString());
        }
        public void Minus(int value)
        {
            this.current -= value;
            Console.WriteLine("value now: " + this.current.ToString());
        }
    }
    public class Client //Invoker
    {
        private List<ACommand> aCommands = new List<ACommand>();
        private CalculatorCpu calculatorCpu = new CalculatorCpu();
        private int currentPosition = 0;
        public void Compute(int value)
        {
            ACommand aCommand = new Sum(this.calculatorCpu, value);
            aCommand.Execute();
            this.aCommands = this.aCommands.Take(this.currentPosition).ToList();
            this.aCommands.Add(aCommand);
            this.currentPosition++;
        }
        public void Undo()
        {
            if (this.currentPosition == 0) return;
            this.aCommands[--this.currentPosition].UnExecute();
        }
        public void Redo()
        {
            if (this.currentPosition + 1 >= this.aCommands.Count) return;
            this.aCommands[++this.currentPosition].Execute();
        }
    }
}
