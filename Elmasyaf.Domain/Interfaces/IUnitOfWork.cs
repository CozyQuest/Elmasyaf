using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Domain.Entities;

namespace Elmasyaf.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Property> Properties { get; }
        IBaseRepository<User> Users { get; }
        Task<int> SaveChangesAsync();
    }
}
