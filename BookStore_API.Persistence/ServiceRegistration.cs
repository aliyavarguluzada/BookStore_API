using BookStore_API.Application.Abstraction;
using BookStore_API.Persistence.Concretes;
using BookStore_API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_API.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(options => options.UseNpgsql("User Id=postgres;Database=BookStore_API_Db;Password=admin123;Host=localhost;Port=5432"));
        }
    }
}
