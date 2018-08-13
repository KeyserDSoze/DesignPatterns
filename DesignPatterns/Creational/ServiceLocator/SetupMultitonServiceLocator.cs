using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.ServiceLocator
{
    public class SetupMultitonServiceLocator : DesignPattern, IDesignPattern
    {
        public static SetupMultitonServiceLocator Instance
        {
            get
            {
                MultitonServiceLocator.Register<ICustomerRepository>(new CustomerRepository());
                Customer c = new CustomerService().GetCustomer(54);
                return null;
            }
        }
    }
    public static class MultitonServiceLocator
    {
        private readonly static Dictionary<Type, object> configuredServices = new Dictionary<Type, object>();

        public static T GetConfiguredService<T>()
        {
            return (T)MultitonServiceLocator.configuredServices[typeof(T)];
        }

        public static void Register<T>(T service)
        {
            MultitonServiceLocator.configuredServices[typeof(T)] = service;
        }
    }
    public class Customer
    {
    }
    public interface ICustomerService
    {
        Customer GetCustomer(int id);
    }
    public interface ICustomerRepository
    {
        Customer GetCustomerFromDatabase(int id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerFromDatabase(int id)
        {
            return new Customer();
        }
    }
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;

        public CustomerService()
        {
            this.customerRepository = MultitonServiceLocator.GetConfiguredService<ICustomerRepository>();
        }

        public Customer GetCustomer(int id)
        {
            return this.customerRepository.GetCustomerFromDatabase(id);
        }
    }
}
