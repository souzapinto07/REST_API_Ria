using FluentValidation;
using Ria.Domain.Common.Entities;
using Ria.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Domain.Customers.Entities
{
    public class Customer : Entity
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public int Age { get;  set; }

        //EF
        public Customer()
        {
            
        }

        public Customer(string firstName, string lastName, int age, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            SetId(id);

            //Validate();
        }

        public bool IsValid()
        {
            var validator = new CustomerValidator().Validate(this);

            if (!validator.IsValid)
            {
               AddErrorMsg(validator);
                return false;
            }
            return true;
        }

        //public string Validate()
        //{
        //    string msg = "";
        //    var validator = new CustomerValidator().Validate(this);

        //    if (!validator.IsValid)
        //    {
        //        msg = AddErrorMsg(validator);
        //    }
        //    return msg;
        //}

        //protected void Validate()
        //{
        //    var validator = new CustomerValidator().Validate(this);

        //    if (!validator.IsValid)
        //    {
        //        throw new DomainException(AddErrorMsg(validator));
        //    }
        //}
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly int AGE_MIN = 18;
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannot be empty").WithErrorCode("1");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty").WithErrorCode("2");
            RuleFor(x => x.Age).GreaterThan(AGE_MIN).WithMessage($"Age needs to be greater than {AGE_MIN}").WithErrorCode("3");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Role cannot be empty").WithErrorCode("4");
        }
    }
}
