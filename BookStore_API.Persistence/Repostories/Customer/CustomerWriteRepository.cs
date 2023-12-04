using BookStore_API.Application.Repositories;
using BookStore_API.Domain.Entities;
using BookStore_API.Persistence.Contexts;

namespace BookStore_API.Persistence.Repostories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(BookStoreDbContext context) : base(context)
        {
        }
    }
}
