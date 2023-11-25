using BookStore_API.Application.Repositories;
using BookStore_API.Domain.Entities.Common;
using BookStore_API.Persistence.Contexts.Contexts;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System.Linq.Expressions;

namespace BookStore_API.Persistence.Repostories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly BookStoreDbContext _context;

        public ReadRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method) => await Table.FirstOrDefaultAsync(method);
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);
        public async Task<T> GetByIdAsync(string id)
           //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
           => await Table.FindAsync(id);


    }
}
