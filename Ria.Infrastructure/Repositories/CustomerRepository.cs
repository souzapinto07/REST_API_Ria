using Microsoft.EntityFrameworkCore;
using Ria.Domain.Common.Data;
using Ria.Domain.Customers.Entities;
using Ria.Domain.Customers.Repositories;
//using Ria.Infrastructure.Data;
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
        private readonly string _filePath = "customers.json";
        private List<Customer> _customers = new();

        public CustomerRepository()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonSerializer.Deserialize<List<Customer>>(json);
                if (data != null)
                {
                    _customers = data;
                }
            }
        }

        public async Task<List<Customer>> GetCustomers()
        {
          return  _customers;
        }

        public bool Exists(int id)
        {
          return  _customers.Any(c => c.Id == id);
        }


        public void CreateCustomer(Customer newCustomer)
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

        private void Save()
        {
            var json = JsonSerializer.Serialize(_customers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void Dispose()
        {
            //_context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
