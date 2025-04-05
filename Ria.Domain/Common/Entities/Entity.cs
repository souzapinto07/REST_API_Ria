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

        public void SetId(int id)
        {
            Id = id;
        }


        public string AddErrorMsg(ValidationResult validationResult)
        {
            string message = "";
            foreach (var failure in validationResult.Errors)
            {
                message += "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage + ".";
            }
            return message;
        }
    }
}
