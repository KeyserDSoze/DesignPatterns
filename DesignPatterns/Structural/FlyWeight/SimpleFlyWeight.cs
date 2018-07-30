using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.FlyWeight
{
    public class SimpleFlyWeight : DesignPattern, IDesignPattern
    {
        public static SimpleFlyWeight Instance
        {
            get
            {
                MoneyFactory moneyFactory = new MoneyFactory();
                IMoney money = moneyFactory.SetMoney(MoneyType.Metallic);
                money.GetMoney(4);
                money = moneyFactory.SetMoney(MoneyType.Metallic);
                money.GetMoney(2);
                money = moneyFactory.SetMoney(MoneyType.Paper);
                money.GetMoney(3);
                money = moneyFactory.SetMoney(MoneyType.Paper);
                money.GetMoney(1);
                Console.WriteLine("Number of Money created: " + MoneyFactory.MoneyCount.ToString());
                return null;
            }
        }
    }
    public enum MoneyType
    {
        Metallic,
        Paper
    }
    //flyweight interface
    public interface IMoney
    {
        MoneyType moneyType { get; }
        void GetMoney(int value);
    }
    //concrete flyweight
    public class MetallicMoney : IMoney
    {
        public MoneyType moneyType => MoneyType.Metallic;
        public MetallicMoney()
        {
        }
        public void GetMoney(int value)
        {
            Console.WriteLine(string.Format("{0} currency of {1} Euro.", moneyType.ToString(), value));
        }
    }
    //concrete flyweight
    public class PaperMoney : IMoney
    {
        public MoneyType moneyType => MoneyType.Paper;
        public PaperMoney()
        {
        }
        public void GetMoney(int value)
        {
            Console.WriteLine(string.Format("{0} currency of {1} Euro.", moneyType.ToString(), value));
        }
    }
    //factory flyweight
    public class MoneyFactory
    {
        public static int MoneyCount = 0;
        private Dictionary<MoneyType, IMoney> moneyList;
        public IMoney SetMoney (MoneyType moneyType) // Same as GetFlyWeight()
        {
            if (moneyList == null)
                moneyList = new Dictionary<MoneyType, IMoney>();
            if (moneyList.ContainsKey(moneyType))
                return moneyList[moneyType];
            switch (moneyType)
            {
                case MoneyType.Metallic:
                    moneyList.Add(moneyType, new MetallicMoney());
                    MoneyCount++;
                    break;
                case MoneyType.Paper:
                    moneyList.Add(moneyType, new PaperMoney());
                    MoneyCount++;
                    break;
                default:
                    break;
            }
            return moneyList[moneyType];
        }
    }
}
