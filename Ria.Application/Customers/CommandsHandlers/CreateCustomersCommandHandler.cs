using MediatR;
using Microsoft.EntityFrameworkCore;
using Ria.Application.Customers.Commands;
using Ria.Domain.Common.Exceptions;
using Ria.Domain.Customers.Entities;
using Ria.Domain.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Application.Customers.CommandsHandlers
{
    public class CreateCustomersCommandHandler : IRequestHandler<CreateCustomersCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomersCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(CreateCustomersCommand command, CancellationToken cancellationToken)
        {
            //TODO
            List<string> errors = new List<string>();
            var existingCustomers = await _customerRepository.GetCustomers();
            var existingIds = existingCustomers.Select(c => c.Id).ToList();

            foreach (var customer in command.Customers)
            {

                if (existingIds.Contains(customer.Id))
                {
                    errors.Add($"Id:{customer.Id} already exists");
                }

                if (errors.Count == 0)
                {
                    var newCustomer = new Customer(customer.FirstName, customer.LastName, customer.Age, customer.Id);

                    //TODO
                    // Find insertion position manually
                    int insertAt = FindInsertionIndex(existingCustomers, newCustomer);
                    existingCustomers.Insert(insertAt, newCustomer);
                    existingIds.Add(newCustomer.Id);

                    //_customerRepository.CreateCustomer(newCustomer);
                }

            }


            if (errors.Count > 0)
            {
                throw new DomainException(string.Join(", ", errors));
            }

            // TODO
            // Clear and rebuild the database table to maintain order
            //_context.Customers.RemoveRange(await _context.Customers.ToListAsync());
            //await _context.Customers.AddRangeAsync(existingCustomers);
            //await _context.SaveChangesAsync();


            await _customerRepository.UnitOfWork.Commit();

            return true;
        }

        // TODO
        private int FindInsertionIndex(List<Customer> existingCustomers, Customer newCustomer)
        {
            for (int i = 0; i < existingCustomers.Count; i++)
            {
                var comparison = string.Compare(existingCustomers[i].LastName, newCustomer.LastName, StringComparison.OrdinalIgnoreCase);
                if (comparison > 0 ||
                    (comparison == 0 && string.Compare(existingCustomers[i].FirstName, newCustomer.FirstName, StringComparison.OrdinalIgnoreCase) > 0))
                {
                    return i;
                }
            }
            return existingCustomers.Count;
        }
    }
}
