using Ria.Domain.Common.Data;
using Ria.Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Domain.Customers.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetCustomers();
        void CreateUser(Customer customer);
    }
}
