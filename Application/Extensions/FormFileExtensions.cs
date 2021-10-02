using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Application.Extensions
{
    public static class FormFileExtensions
    {
        private const string roothPath = @"C:\HouseProject_Attachments";

        public static string SaveFile(this IFormFile formFile)
        {

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
