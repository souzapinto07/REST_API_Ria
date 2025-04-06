using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Domain.Common.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        private bool HasError { get; set; } = false;

        private string? ErrorMessage { get; set; }


        public void SetId(int id)
        {
            Id = id;
        }

        public abstract bool Validate();

        public void AddErrorMsg(ValidationResult validationResult)
        {
            foreach (var failure in validationResult.Errors)
            {
                HasError = true;
                ErrorMessage += "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage + ".";
            }
        }
        public string? GetErrorMsg()
        {
            return ErrorMessage;
        }
        public bool IsValid()
        {
            return !HasError;
        }
    }
}
