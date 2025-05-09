﻿using FluentValidation;
using Ria.Application.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Application.Customers.Contracts.Request
{
    public record CreateCustomerDTO
    {
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public int Age { get; private set; }
        public int Id { get; private set; }

        public CreateCustomerDTO(string lastName, string firstName, int age, int id)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Id = id;
        }
    }

    public class CreateCustomerDTOValidation : AbstractValidator<CreateCustomerDTO>
    {
        public CreateCustomerDTOValidation()
        {
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be empty").WithErrorCode("1");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannot be empty").WithErrorCode("2");
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("Age needs to be greater than 0").WithErrorCode("3");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Role cannot be empty").WithErrorCode("4");
        }
    }
}
