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
            services.AddDbContext<BookStoreDbContext>(options => options.UseNpgsql("User ID=postgres;Password=admin123;Host=localhost;Port=5432;Database=BookStore_API_Db;"), ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
