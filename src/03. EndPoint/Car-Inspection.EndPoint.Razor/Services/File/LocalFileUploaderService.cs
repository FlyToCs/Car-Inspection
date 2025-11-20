namespace Car_Inspection.EndPoint.Razor.Services.File;


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;

public class LocalFileUploaderService(IWebHostEnvironment webHostEnvironment) : IFileUploaderService
{
    public List<string> UploadImages(List<IFormFile> files, string folderName)
    {
        if (files == null || files.Count == 0)
        {
            return new List<string>();
        }

        var urls = new List<string>();
        string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, folderName);

     
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        foreach (var file in files)
        {
            if (file.Length > 0)
            {
                
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadPath, uniqueFileName);

           
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

              
                string relativeUrl = $"/{folderName}/{uniqueFileName}";
                urls.Add(relativeUrl);
            }
        }

        return urls;
    }
}