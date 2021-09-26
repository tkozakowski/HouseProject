using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class FormFileExtensions
    {
        public static string SaveFile(this IFormFile formFile, IConfiguration configuration)
        {
            string roothPath = configuration.GetValue<string>("FilePath");
            if (!Directory.Exists(roothPath))
                Directory.CreateDirectory(roothPath);

            string filePath = Path.Combine(roothPath, $"{Guid.NewGuid()}_{formFile.FileName}");

            using(Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return filePath;
        }


        public static byte[] GetBytes(this IFormFile formFile)
        {
            using(var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
