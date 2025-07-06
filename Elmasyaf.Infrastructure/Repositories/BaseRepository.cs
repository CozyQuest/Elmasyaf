using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmasyaf.Domain.Interfaces;
using Elmasyaf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Elmasyaf.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, ISoftDeletable
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => EF.Property<long>(e, "Id") == id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
        }
    }
}
