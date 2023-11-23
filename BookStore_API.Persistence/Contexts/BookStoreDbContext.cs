using BookStore_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_API.Persistence.Contexts
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

