using BookStore_API.Application.Repostories;
using BookStore_API.Domain.Entities.Common;

namespace BookStore_API.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddAsync(List<T> model);
        Task<bool> UpdateAsync(T model);
        Task<bool> RemoveAsync(T model);
        Task<bool> RemoveAsync(string id);
    }
}
