﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Mediator
{
    public class Mediator : DesignPattern, IDesignPattern
    {
        public static Mediator Instance
        {
            get
            {
                AUser userA = new ImplementationAUser() { Username = "KeyserDSoze" };
                AUser userB = new ImplementationBUser() { Username = "Theos" };
                ChatRoom chatRoom = new ChatRoom();
                chatRoom.Register(userA);
                chatRoom.Register(userB);
                chatRoom.Send(userA.Username, userB.Username, "Hi");
                chatRoom.Send(userB.Username, userA.Username, "Hello");
                return null;
            }
        }
    }
    public abstract class AChatRoom
    {
        private Dictionary<string, AUser> users = new Dictionary<string, AUser>();
        public void Register(AUser user)
        {
            if (!this.users.ContainsKey(user.Username)) this.users.Add(user.Username, user);
        }
        public void Send(string from, string to, string message)
        {
            if(this.users.ContainsKey(from) && this.users.ContainsKey(to))
            {
                this.users[to].Receive(from, message);
            }
        }
    }
    public class ChatRoom : AChatRoom
    {

    }
    public abstract class AUser
    {
        public string Username { get; set; }
        private AChatRoom chatRoom = new ChatRoom();  //dependency injection
        public void Send(string to, string message)
        {
            chatRoom.Send(this.Username, to, message);
        }
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
              from, this.Username, message);
        }
    }
    //two different implementation cause a different data retrieving or other
    public class ImplementationAUser : AUser
    {
        public string Image { get; set; }
        public string Description { get; set; }
    }
    public class ImplementationBUser : AUser
    {
        public string Thumbnail { get; set; }
        public List<ImplementationBUser> friends = new List<ImplementationBUser>();
    }
}
