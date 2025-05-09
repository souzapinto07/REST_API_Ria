﻿using MediatR;
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
            List<string> errors = new List<string>();

            foreach (var customer in command.Customers)
            {
             
                if (_customerRepository.Exists(customer.Id))
                {
                    errors.Add($"Id: {customer.Id} already exists");
                    continue;
                }

                var newCustomer = new Customer(customer.LastName, customer.FirstName, customer.Age, customer.Id);

                if(!newCustomer.IsValid())
                {
                    errors.Add($"Id:{customer.Id} {newCustomer.GetErrorMsg()}");
                    continue;
                }

                _customerRepository.CreateCustomer(newCustomer);

            }

            if (errors.Count > 0)
            {
                throw new DomainException("Some customers failed.", errors);
            }

            return await Task.FromResult(true);
        }

       
    }
}
