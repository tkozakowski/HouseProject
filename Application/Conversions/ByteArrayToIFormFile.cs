using Microsoft.AspNetCore.Http;
using System.IO;

namespace Application.Conversions
{
    public class ByteArrayToIFormFile
    {
        public static IFormFile ConvertByteArrayToIFormFile(byte[] byteArray, string fileName)
        {
            using (var stream = new MemoryStream(byteArray))
            {
                var file = new FormFile(stream, 0, byteArray.Length, "name", fileName)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = System.Net.Mime.MediaTypeNames.Application.Octet,
                };

                System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = file.FileName
                };

                file.ContentDisposition = cd.ToString();
                
                return file;
            }
        }
    }
}
