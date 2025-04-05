using Microsoft.EntityFrameworkCore;
using Ria.Domain.Common.Data;
using Ria.Domain.Customers.Entities;
using Ria.Domain.Customers.Repositories;
using Ria.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWork UnitOfWork => _context;


        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }
        public void CreateUser(Customer customer)
        {
            _context.Customer.Add(customer);
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
