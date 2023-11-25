using BookStore_API.Persistence.Contexts.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BookStore_API.Persistence.Repostories;
using BookStore_API.Application.Repositories;

namespace BookStore_API.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //TODO:Do not hardcode ConnectionString use appsettings.json
            services.AddDbContext<BookStoreDbContext>(options => options.UseNpgsql("User ID=postgres;Password=admin123;Host=localhost;Port=5432;Database=BookStore_API_Db;"));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
