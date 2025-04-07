using Ria.Domain.Customers.Entities;
using Ria.Domain.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ria.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly object _lock = new object();
        private readonly string FILE_PATH = "customers.json";
        private List<Customer> _customers = new List<Customer>();

        public CustomerRepository()
        {
            lock (_lock)
            {
                if (File.Exists(FILE_PATH))
                {
                    var json = File.ReadAllText(FILE_PATH);
                    var data = JsonSerializer.Deserialize<List<Customer>>(json);
                    if (data != null)
                    {
                        _customers = data;
                    }
                }
            }
        }

        public List<Customer> GetCustomers()
        {
            lock (_lock)
            {
                return new List<Customer>(_customers);
            }
        }

        public bool Exists(int id)
        {
            lock (_lock)
            {
                return _customers.Exists(c => c.Id == id);
            }
        }

        public void CreateCustomer(Customer newCustomer)
        {
            lock (_lock)
            {
                int i = 0;
                while (i < _customers.Count &&
                      (_customers[i].LastName.CompareTo(newCustomer.LastName) < 0 ||
                      (_customers[i].LastName == newCustomer.LastName &&
                       _customers[i].FirstName.CompareTo(newCustomer.FirstName) < 0)))
                {
                    i++;
                }
                _customers.Insert(i, newCustomer);
                Save();
            }
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_customers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FILE_PATH, json);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }


}
