using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.InversionOfControl
{
    public class IoCDependencyInjection : DesignPattern, IDesignPattern
    {
        public static UserLogin Instance
        {
            get
            {
                UserLogin user = new UserLogin(new DatabaseSqlWhereTheUserIsSaved());
                Console.WriteLine("When i inject a Sql Saver class i get: ");
                user.Save();
                user = new UserLogin(new TablestorageWhereTheUserIsSaved());
                Console.WriteLine("When i inject a Tablestorage saver class i get: ");
                user.Save();
                return user;
            }
        }
    }
    public class UserLogin
    {
        IUserDB userDB;
        public UserLogin(IUserDB userDB)
        {
            this.userDB = userDB;
        }
        public void Save()
        {
            this.userDB.Save();
        }
    }
    public interface IUserDB
    {
        void Save();
    }
    public class DatabaseSqlWhereTheUserIsSaved : IUserDB
    {
        public void Save()
        {
            Console.WriteLine("Save User in DB sql");
        }
    }
    public class TablestorageWhereTheUserIsSaved : IUserDB
    {
        public void Save()
        {
            Console.WriteLine("Save User in Tablestorage");
        }
    }
}
