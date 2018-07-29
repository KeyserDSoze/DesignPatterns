using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    public class Adapter : DesignPattern, IDesignPattern
    {
        public static Adapter Instance
        {
            get
            {
                Customer c = new Customer() { TokenID = "8293jmkm0", StartTime = DateTime.Now };
                Console.WriteLine("Old integration of Customer: " + c.ToString());
                DetailedCustomer cc = new DetailedCustomer() { TokenID = "8293jmkm0", StartTime = DateTime.Now };
                Console.WriteLine("Adapting integration of Customer: " + cc.ToString());
                return null;
            }
        }
    }
    //target class that probabily is used in another part of software, but with our smart we think that there's a possibility to reuse in this case.
    //How can we do it? With Adapter Design Pattern. It's easy.
    public class Customer
    {
        public string TokenID { get; set; }
        public DateTime StartTime { get; set; }
        public override string ToString()
        {
            return "User: " + this.TokenID + " at " + this.StartTime.ToString();
        }
    }
    //adapter class
    public class DetailedCustomer : Customer
    {
        public DetailOfCustomer DetailOfCustomer { get; set; }
        public DetailedCustomer()
        {
            this.DetailOfCustomer = new DetailOfCustomer(this.TokenID);
        }
        public override string ToString()
        {
            return "User: " + this.TokenID + " at " + this.StartTime.ToString() + " with Name: " + this.DetailOfCustomer.Name + " and Surname: " + this.DetailOfCustomer.Surname;
        }
    }
    //adaptee class
    public class DetailOfCustomer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DetailOfCustomer(string tokenID)
        {
            SetDataFromDatabase(tokenID);
        }
        private void SetDataFromDatabase(string tokenID)
        {
            //get data from DB, in this example I set a default value
            //getDataFromDB(tokenID); //example of call to DB
            this.Name = "Keyser";
            this.Surname = "Soze";
        }
    }
}
