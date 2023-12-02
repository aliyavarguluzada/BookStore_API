using BookStore_API.Application.Repositories;
using BookStore_API.Domain.Entities;
using BookStore_API.Persistence.Contexts.Contexts;

namespace BookStore_API.Persistence.Repostories
{
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
