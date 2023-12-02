using File = BookStore_API.Domain.Entities.File;

namespace BookStore_API.Application.Repositories
{
    public interface IFileWriteRespository : IWriteRepository<File>
    {
    }
}
