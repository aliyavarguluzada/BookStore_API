using BookStore_API.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;

namespace BookStore_API.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorageService _storageService;

        public StorageService(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public Task DeleteAsync(string pathOrContainer, string fileName) =>
            _storageService.DeleteAsync(pathOrContainer, fileName);


        public List<string> GetFiles(string pathOrContainer) =>
            _storageService.GetFiles(pathOrContainer);


        public bool HasFile(string pathOrContainer, string fileName) =>
            _storageService.HasFile(pathOrContainer, fileName);


        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        => _storageService.UploadAsync(pathOrContainerName, files);
    }
}
