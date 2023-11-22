using BookStore_API.Application.Abstraction;
using BookStore_API.Domain.Entities;

namespace BookStore_API.Persistence.Concretes
{
    public class BookService : IBookService
    {
        public List<Book> GetBooks() => new()
        {
            new(){Id = Guid.NewGuid(), Name = "Book 1", Price = 10, Stock = 15, CreatedDate = DateTime.Now},
            new(){Id = Guid.NewGuid(), Name = "Book 2", Price = 20, Stock = 25, CreatedDate = DateTime.Now},
            new(){Id = Guid.NewGuid(), Name = "Book 3", Price = 30, Stock = 35, CreatedDate = DateTime.Now},
            new(){Id = Guid.NewGuid(), Name = "Book 4", Price = 40, Stock = 45, CreatedDate = DateTime.Now},
            new(){Id = Guid.NewGuid(), Name = "Book 5", Price = 50, Stock = 55, CreatedDate = DateTime.Now}
        };
    }
}
