using BookStore_API.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace BookStore_API.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public Task DeleteAsync(string pathOrContainer, string fileName) =>
            _storage.DeleteAsync(pathOrContainer, fileName);


        public List<string> GetFiles(string pathOrContainer) =>
            _storage.GetFiles(pathOrContainer);


        public bool HasFile(string pathOrContainer, string fileName) =>
            _storage.HasFile(pathOrContainer, fileName);


        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        => _storage.UploadAsync(pathOrContainerName, files);
    }
}
