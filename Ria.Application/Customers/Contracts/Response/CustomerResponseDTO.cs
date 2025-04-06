using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Application.Customers.Contracts.Response
{
    public record CustomerResponseDTO
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public int Id { get; private set; }

        public CustomerResponseDTO(string firstName, string lastName, int age, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Id = id;
        }
    }
}
