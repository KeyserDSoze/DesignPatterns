using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Interpreter
{
    public class Interpreter : DesignPattern, IDesignPattern
    {
        public static Interpreter Instance
        {
            get
            {
                Client client = new Client() { Formula = "C5H8" };
                List<IAtom> atomsToCheck = new List<IAtom>();
                atomsToCheck.Add(new Hydrogen());
                atomsToCheck.Add(new Carbon());
                double totalMass = 0;
                foreach (IAtom atom in atomsToCheck)
                {
                    totalMass += atom.Convert(client);
                }
                Console.WriteLine("Total Weight of C5H8: " + totalMass.ToString());
                return null;
            }
        }
    }
    public class Client
    {
        public string Formula { get; set; }
    }
    public interface IAtom
    {
        double Convert(Client client);
    }
    public class Hydrogen : IAtom
    {
        public double Convert(Client client)
        {
            if (client.Formula.ToLower().Contains("h"))
            {
                Regex regex = new Regex("h[0-9]*"); //to get how many atoms of hydrogen it's composed
                if (regex.IsMatch(client.Formula.ToLower()))
                {
                    return int.Parse(regex.Match(client.Formula.ToLower()).Value.ToLower().Replace("h", "")) * 1.007;
                }
                return 1.007;
            }
            return 0;
        }
    }
    public class Carbon : IAtom
    {
        public double Convert(Client client)
        {
            if (client.Formula.ToLower().Contains("c")) {
                Regex regex = new Regex("c[0-9]*"); //to get how many atoms of carbon it's composed
                if (regex.IsMatch(client.Formula.ToLower()))
                {
                    return int.Parse(regex.Match(client.Formula.ToLower()).Value.ToLower().Replace("c", "")) * 12;
                }
                return 12;
            }
            return 0;
        }
    }
}
