using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Domain.Entities;
using Elmasyaf.Domain.Interfaces;
using Elmasyaf.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Elmasyaf.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBaseRepository<Property> Properties { get; private set; }
        public IBaseRepository<User> Users { get; private set; }
        public UnitOfWork(AppDbContext context, IBaseRepository<Property> baseRepository, IBaseRepository<User> users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Properties = baseRepository ?? throw new ArgumentNullException(nameof(baseRepository));
            Users = users;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
