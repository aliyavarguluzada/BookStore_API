using BookStore_API.Application.Repostories;
using BookStore_API.Domain.Entities.Common;

namespace BookStore_API.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> data);
        bool Update(T model);
        bool Remove(T model);
        bool RemoveRange(List<T> data);
        Task<bool> RemoveAsync(string id);
        Task<int> SaveAsync();
    }
}
