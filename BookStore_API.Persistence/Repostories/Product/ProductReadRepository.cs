using BookStore_API.Domain.Entities;
using BookStore_API.Application.Repositories;
using BookStore_API.Persistence.Contexts;

namespace BookStore_API.Persistence.Repostories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
