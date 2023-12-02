using BookStore_API.Application.Repositories;
using BookStore_API.Persistence.Contexts.Contexts;
using File = BookStore_API.Domain.Entities.File;

namespace BookStore_API.Persistence.Repostories
{
    public class FileReadRepository : ReadRepository<File>, IFileReadRepository
    {
        public FileReadRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
