using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade
{
    public class SimpleFacade : DesignPattern, IDesignPattern
    {
        public static SimpleFacade Instance
        {
            get
            {
                Site site = new Site();
                Console.WriteLine(site.GetValues());
                return null;
            }
        }
    }
    //First class
    public class Config
    {
        public string Get()
        {
            return "Get Site Configuration";
        }
    }
    //Second class
    public class Design
    {
        public string Get()
        {
            return "Get Site Design";
        }
    }
    //Third class
    public class Contents
    {
        public string Get()
        {
            return "Get Site Contents";
        }
    }
    //Facade class
    public class Site
    {
        private readonly Config config;
        private readonly Design design;
        private readonly Contents contents;
        public Site()
        {
            this.config = new Config();
            this.design = new Design();
            this.contents = new Contents();
        }
        public string GetValues()
        {
            return this.config.Get() + "|" + this.design.Get() + "|" + this.contents.Get();
        }
    }
}
