using Microsoft.AspNetCore.Http;

namespace BookStore_API.Application.Services
{
    public interface IFileService
    {
        Task UploadAsync(string path, IFormFileCollection files);
        Task<string>FileRenameAsync(string fileName);
        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}
