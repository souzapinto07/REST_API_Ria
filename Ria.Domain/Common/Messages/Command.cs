using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Domain.Common.Messages
{
    public abstract class Command<T> : Message, IRequest<T>
    {
        public DateTime Timestamp { get; private set; }

        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
