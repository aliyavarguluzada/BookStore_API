using BookStore_API.Application.Abstractions.Storage;
using BookStore_API.Application.Abstractions.Storage.Azure;
using BookStore_API.Application.Abstractions.Storage.Local;
using BookStore_API.Infrastructure.Enums;
using BookStore_API.Infrastructure.Services.Storage;
using BookStore_API.Infrastructure.Services.Storage.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BookStore_API.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, ILocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, ILocalStorage>();
                    break;
            }
        }
    }
}
