using BookStore_API.Application.Services;
using BookStore_API.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStore_API.Infrastructure.Services
{
    public class FileService : IFileService
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //TODO: logging!!!!
                throw ex;
            }

        }

        async Task<string> FileRenameAsync(string path, string fileName, bool first = true)
        {
            string newFileName = await Task.Run(async () =>
              {
                  string extension = Path.GetExtension(fileName);


                  string newFileName = String.Empty;

                  if (first)
                  {
                      string oldFileName = Path.GetFileNameWithoutExtension(fileName);
                      newFileName = $"{NameOperation.CharacterRegulatory(oldFileName)}{extension}";
                  }
                  else
                  {
                      newFileName = fileName;
                      int count = 1;
                      int hyphenIndex = newFileName.IndexOf("-");

                      if (hyphenIndex == -1)
                          newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                      else
                      {
                          int lastIndex = 0;

                          while (newFileName.IndexOf("-", hyphenIndex + 1) != -1)
                          {
                              lastIndex = hyphenIndex;
                              lastIndex = newFileName.IndexOf("-", hyphenIndex + 1);
                              if (hyphenIndex == -1)
                              {
                                  hyphenIndex = lastIndex;
                                  break;
                              }
                          }


                          int index_2 = newFileName.IndexOf(".");
                          string fileNo = newFileName.Substring(hyphenIndex + 1, index_2 - hyphenIndex - 1);

                          if (int.TryParse(fileNo, out int _fileNo))
                          {
                              _fileNo++;
                              newFileName = newFileName.Remove(hyphenIndex + 1, index_2 - hyphenIndex - 1).Insert(hyphenIndex, _fileNo.ToString());
                          }
                          else
                          {
                              newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-{+1000}{extension}";

                          }



                      }
                  }




                  if (File.Exists($"{path}\\{newFileName}"))
                      return await FileRenameAsync(path, newFileName, false);
                  else
                      return newFileName;

              });
            return newFileName;
        }

        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();

            List<bool> results = new();


            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(uploadPath, file.FileName);

                bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
                results.Add(result);
            }


            if (results.TrueForAll(r => r.Equals(true)))
                return datas;

            //TODO: should form Exception in case of if case below return false
            return null;
        }
    }
}
