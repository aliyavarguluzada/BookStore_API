using BookStore_API.Application.Services;
using BookStore_API.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore_API.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void InfrastructureService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
        }
    }
}
