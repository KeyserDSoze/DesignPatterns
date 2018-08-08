using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer
{
    public class Observer : DesignPattern, IDesignPattern
    {
        public static Observer Instance
        {
            get
            {
                ChatRoom chatRoom = new ChatRoom();
                User a = new User(chatRoom);
                User b = new User(chatRoom);
                User c = new User(chatRoom);
                chatRoom.Add(a);
                chatRoom.Add(b);
                chatRoom.Add(c);
                a.SendMessage("Hello People!!!");
                return null;
            }
        }
    }
    public interface IObservable
    {
        void Add(IObserver user);
        void Remove(IObserver user);
        void Notify();
    }
    public interface IObserver
    {
        void Update();
    }
    public class ChatRoom : IObservable
    {
        public List<IObserver> Users = new List<IObserver>();
        public List<string> Messages { get; set; } = new List<string>();
        public void Add(IObserver user)
        {
            this.Users.Add(user);
        }

        public void Notify()
        {
            foreach (IObserver user in this.Users) user.Update();
        }

        public void Remove(IObserver user)
        {
            this.Users.Remove(user);
        }
        public void MessageSent(string message)
        {
            this.Messages.Add(message);
            this.Notify();
        }
        public string GetLastMessage()
        {
            return this.Messages.LastOrDefault();
        }
    }
    public class User : IObserver
    {
        public ChatRoom ChatRoom;
        public User(ChatRoom chatRoom)
        {
            this.ChatRoom = chatRoom;
        }
        public void Update()
        {
            Console.WriteLine("Message received: " + this.ChatRoom.GetLastMessage());
        }
        public void SendMessage(string Message)
        {
            this.ChatRoom.MessageSent(Message);
        }
    }
}
