using MediatR;
using Ria.Application.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Application.Customers.CommandsHandlers
{
    public class CreateCustomersCommandHandler : IRequestHandler<CreateCustomersCommand, bool>
    {
        //private readonly IUserRepository _userRepository;


        public async Task<bool> Handle(CreateCustomersCommand command, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
