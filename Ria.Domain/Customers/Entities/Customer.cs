﻿using FluentValidation;
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
        public string LastName { get;  set; }
        public string FirstName { get;  set; }
        public int Age { get;  set; }

        public Customer(string lastName, string firstName, int age, int id)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            SetId(id);

            Validate();
        }
        public override bool Validate()
        {
            var validator = new CustomerValidator().Validate(this);

            if (!validator.IsValid)
            {
                AddErrorMsg(validator);
                return false;
            }
            return true;
        }
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly int AGE_MIN = 18;
        public CustomerValidator()
        {
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty").WithErrorCode("1");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannot be empty").WithErrorCode("2");
            RuleFor(x => x.Age).GreaterThan(AGE_MIN).WithMessage($"Age needs to be greater than {AGE_MIN}").WithErrorCode("3");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Role cannot be empty").WithErrorCode("4");
        }
    }
}
