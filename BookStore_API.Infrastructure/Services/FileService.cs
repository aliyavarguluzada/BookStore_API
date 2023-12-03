using BookStore_API.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;

namespace BookStore_API.Infrastructure.Services
{
    public class FileService
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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




    }
}
