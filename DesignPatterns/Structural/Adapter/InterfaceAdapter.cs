using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    public class InterfaceAdapter : DesignPattern, IDesignPattern
    {
        public static InterfaceAdapter Instance
        {
            get
            {
                IMessage message = new Message(new SpecialMessage()) { Text = "Hello!!!" };
                message.Send();
                return null;
            }
        }
    }
    public interface IMessage
    {
        void Send();
    }
    public class Message : IMessage
    {
        private SpecialMessage specialMessage;
        public string Text { get; set; }
        public Message(SpecialMessage specialMessage)
        {
            this.specialMessage = specialMessage;
        }
        public void Send()
        {
            this.specialMessage.SpecialSend(this.Text);
        }
    }
    public class SpecialMessage
    {
        public void SpecialSend(string text)
        {
            Console.WriteLine("Special: " + text);
        }
    }
}
