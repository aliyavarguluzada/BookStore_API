using BookStore_API.Application.Repositories;
using BookStore_API.Persistence.Contexts;
using File = BookStore_API.Domain.Entities.File;

namespace BookStore_API.Persistence.Repostories
{
    public class FileWriteRepository : WriteRepository<File>, IFileWriteRespository
    {
        public FileWriteRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
