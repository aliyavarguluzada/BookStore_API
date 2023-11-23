using BookStore_API.Persistence.Contexts.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //TODO:Do not hardcode ConnectionString use appsettings.json
            services.AddDbContext<BookStoreDbContext>(options => options.UseNpgsql("User ID=postgres;Password=admin123;Host=localhost;Port=5432;Database=BookStore_API_Db;"));
        }
    }
}
