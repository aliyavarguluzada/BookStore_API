using BookStore_API.Application.Repositories;
using BookStore_API.Domain.Entities;
using BookStore_API.Persistence.Contexts.Contexts;
namespace BookStore_API.Persistence.Repostories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
