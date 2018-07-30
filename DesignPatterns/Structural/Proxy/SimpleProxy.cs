using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Proxy
{
    public class SimpleProxy : DesignPattern, IDesignPattern
    {
        public static SimpleProxy Instance
        {
            get
            {
                XmlParser xmlParser = new XmlParser("Sample");
                Console.WriteLine("XmlParser Instance Created");
                Console.WriteLine("Number of news: " + xmlParser.GetNumberNews());
                Console.WriteLine(" ");
                ProxyLazyXmlParser proxyLazyXmlParser = new ProxyLazyXmlParser("Sample");
                Console.WriteLine("ProxyLazyXmlParser Instance Created");
                Console.WriteLine("Number of news: " + proxyLazyXmlParser.GetNumberNews());
                Console.WriteLine(" ");
                ProxyRemoteXmlParser proxyRemoteXmlParser = new ProxyRemoteXmlParser("Sample");
                Console.WriteLine("ProxyRemoteXmlParser Instance Created");
                Console.WriteLine("Number of news: " + proxyRemoteXmlParser.GetNumberNews());
                Console.WriteLine(" ");
                ProxyProtectionXmlParser proxyProtectionXmlParser = new ProxyProtectionXmlParser("Sample");
                Console.WriteLine("ProxyProtectionXmlParser Instance Created");
                Console.WriteLine("Number of news: " + proxyProtectionXmlParser.GetNumberNews());
                return null;
            }
        }
    }
    public interface IXmlParser
    {
        int GetNumberNews();
    }
    public class XmlParser : IXmlParser
    {
        public List<News> news = new List<News>();
        public XmlParser(string url)
        {
            Console.WriteLine("Load Xml From Url");
            this.news.Add(new News());
            this.news.Add(new News());
            this.news.Add(new News());
            this.news.Add(new News());
        }
        public int GetNumberNews()
        {
            return this.news.Count;
        }
        public class News
        {

        }
    }
    //Proxy for Virtual (Cache, Laziness, Resourse that expensive to create)
    public class ProxyLazyXmlParser : IXmlParser
    {
        private string url;
        private XmlParser xmlParser;
        public ProxyLazyXmlParser(string url)
        {
            this.url = url;
        }
        public int GetNumberNews()
        {
            if (this.xmlParser == null) this.xmlParser = new XmlParser(this.url);
            return this.xmlParser.GetNumberNews();
        }
    }
    //Proxy for Remote Request (different server, different namespace, different project)
    public class ProxyRemoteXmlParser : IXmlParser
    {
        private XmlParser xmlParser;
        public ProxyRemoteXmlParser(string url)
        {
            Console.WriteLine("Call a WebService");
            this.xmlParser = new XmlParser(url);
        }
        public int GetNumberNews()
        {
            return this.xmlParser.GetNumberNews();
        }
    }
    //Proxy for Protection
    public class ProxyProtectionXmlParser : IXmlParser
    {
        private string url;
        private XmlParser xmlParser;
        private Account account = new Account();
        public ProxyProtectionXmlParser(string url)
        {
            this.url = url;
        }
        public int GetNumberNews()
        {
            if (!this.account.TokenIsValid)
            {
                Console.WriteLine("Token not valid. You can't obtain the value");
                return -1;
            }
            else
            {
                Console.WriteLine("Token valid. You can obtain the value");
            }
            if (this.xmlParser == null) this.xmlParser = new XmlParser(this.url);
            return this.xmlParser.GetNumberNews();
        }
        public class Account
        {
            public bool TokenIsValid { get; set; }
            public Account()
            {
                this.TokenIsValid = new Random().Next(4) >= 2;
            }
        }
    }
}
