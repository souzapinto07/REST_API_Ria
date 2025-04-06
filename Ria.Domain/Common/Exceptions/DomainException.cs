using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Domain.Common.Exceptions
{
    public class DomainException : Exception
    {
        public string? Code { get; set; }

        public DomainException()
        { }

        public DomainException(string message) : base(message) { }


        //public DomainException(string message, string code) : base(message)
        //{
        //    Code = code;
        //}

        //public DomainException(string message, string code, Exception innerException)
        //    : base(message, innerException)
        //{
        //    Code = code;
        //}
    }
}
