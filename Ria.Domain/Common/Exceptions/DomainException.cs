using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ria.Domain.Common.Exceptions
{
    public class DomainException : Exception
    {
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }

        public DomainException(string message, List<string> errors) : base(message) {
            Message = message;
            Errors = errors;
        }
    }
}
