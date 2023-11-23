using BookStore_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Persistence.Contexts.Contexts
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
