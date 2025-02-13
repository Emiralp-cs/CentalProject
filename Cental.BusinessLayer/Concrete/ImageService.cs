using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ImageService : IImageService
    {


        public async Task<string> SaveImageAsync(IFormFile file, string nameOfTheFileToSave)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {   


                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(currentDirectory, $"wwwroot/{nameOfTheFileToSave}", imageName);
                var stream = new FileStream(saveLocation, FileMode.Create);
                await file.CopyToAsync(stream);
                return $"/{nameOfTheFileToSave}/" + imageName;
            }
            else
            {
                throw new ValidationException("Dosya Formatı Resim Olmalıdır!");
            }

        }
    }
}
