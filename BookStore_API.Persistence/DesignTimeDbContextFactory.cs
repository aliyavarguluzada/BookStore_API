using BookStore_API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_API.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder optionsBuilder = new();
            optionsBuilder.UseNpgsql("User Id=postgres;Database=BookStore_API_Db;Password=admin123;Host=localhost;Port=5432");

            return new (optionsBuilder.Options);
        }
    }
}
