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
        IBaseRepository<Apartment> Apartments { get; }
        Task<int> SaveChangesAsync();
    }
}
