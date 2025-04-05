using FluentValidation;
using Ria.Application.Customers.Contracts.Request;
using Ria.Domain.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Application.Customers.Commands
{
    public class CreateCustomersCommand : Command<bool>
    {
        public List<CreateCustomerDTO> Customers { get; private set; }

        public CreateCustomersCommand(List<CreateCustomerDTO> customers)
        {
            Customers = customers;
        }
    }

    public class CreateCustomersCommandValidator : AbstractValidator<CreateCustomersCommand>
    {
        public CreateCustomersCommandValidator()
        {
            RuleForEach(x => x.Customers).SetValidator(new CreateCustomerDTOValidation());
        }
    }
}
