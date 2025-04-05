using FluentValidation;
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
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public int Id { get; private set; }

        public CreateCustomersCommand(string firstName, string lastName, int age, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Id = id;
        }
    }

    public class CreateCustomersCommandValidation : AbstractValidator<CreateCustomersCommand>
    {
        private readonly int AGE_MIN = 18;
        public CreateCustomersCommandValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannot be empty").WithErrorCode("1");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty").WithErrorCode("2");
            RuleFor(x => x.Age).GreaterThan(AGE_MIN).WithMessage($"Age needs to be greater than {AGE_MIN}").WithErrorCode("3");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Role cannot be empty").WithErrorCode("4");
        }
    }
}
