using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BookStore_API.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_API.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        private readonly BlobServiceClient _blobServiceCLient;
        BlobContainerClient _blobContainerClient;

        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceCLient = new(configuration["Storage:Azure"]);
        }
        public Task DeleteAsync(string pathOrContainer, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles(string pathOrContainer)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string pathOrContainer, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceCLient.GetBlobContainerClient(containerName);

            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            List<(string fileName, string pathOrContainerName)> datas = new();

            foreach (IFormFile file in files)
            {
                BlobClient blobClient = _blobContainerClient.GetBlobClient(file.Name);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((file.Name, containerName));
            }
            return datas;
        }
    }
}
