using Ria.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Domain.Common.Data
{
    public interface IRepository<T> : IDisposable where T : Entity 
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
