using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.InversionOfControl
{
    public class DependencyInjection : DesignPattern, IDesignPattern 
    {
        public static Library Instance
        {
            get
            {
                Library library = new Library(new Book());
                Console.WriteLine("When i inject a book class i get " + library.GetOne());
                library = new Library(new NewsPaper());
                Console.WriteLine("When i inject a newspaper class i get " + library.GetOne());
                return library;
            }
        }
    }
    public class Library
    {
        ILibraryObject libraryObject;
        public Library(ILibraryObject libraryObject)
        {
            this.libraryObject = libraryObject;
        }
        public string GetOne()
        {
            return this.libraryObject.Get();
        }
    }
    public interface ILibraryObject
    {
        string Get();
    }
    public class Book : ILibraryObject
    {
        public string Get()
        {
            return "A Book";
        }
    }
    public class NewsPaper : ILibraryObject
    {
        public string Get()
        {
            return "A NewsPaper";
        }
    }
}
