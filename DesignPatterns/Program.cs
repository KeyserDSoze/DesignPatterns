using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Creational.Singleton;
using System.Reflection;

namespace DesignPatterns
{
    class Program
    {
        static List<Type> types = new List<Type>();
        static void Main(string[] args)
        {
            string result = WhatDoYouWantToSeeInAction();
            if (result == "exit") return;
            do
            {
                try
                {
                    Type type = types[int.Parse(result)];
                    PropertyInfo pi = type.GetProperty("Instance");
                    if (pi != null)
                    {
                        Console.WriteLine("First Attempt: ");
                        pi.GetValue(null, null);
                        if (type.GetInterfaces().ToList().FindAll(x => x.Name.Contains("ITwoAttempt")).Count > 0)
                        {
                            Console.WriteLine("Second Attempt: ");
                            pi.GetValue(null, null);
                        }
                    }
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Press any button to continue");
                    Console.ReadLine();
                }
            } while ((result = WhatDoYouWantToSeeInAction()) != "exit");
        }

        static string WhatDoYouWantToSeeInAction()
        {
            int value = 0;
            if (types.Count == 0) types = Assembly.GetExecutingAssembly().GetTypes().ToList().FindAll(ø => ø.GetInterface("IDesignPattern") != null);
            foreach (Type t in types)
            {
                Console.WriteLine("For " + t.Namespace.Replace("DesignPatterns.", "") + "." + t.Name + " use " + value.ToString());
                value++;
            }
            Console.WriteLine("'exit' if you want to close this app.");
            return Console.ReadLine();
        }
    }
}
