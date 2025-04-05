using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ria.Domain.Common.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
