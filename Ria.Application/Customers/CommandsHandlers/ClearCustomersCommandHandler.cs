using MediatR;
using Ria.Application.Customers.Commands;
using Ria.Domain.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Application.Customers.CommandsHandlers
{
    public class ClearCustomersCommandHandler : IRequestHandler<ClearCustomersCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public ClearCustomersCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<bool> Handle(ClearCustomersCommand request, CancellationToken cancellationToken)
        {
            _customerRepository.ClearCustomers();
            return Task.FromResult(true);
        }
    }
}
