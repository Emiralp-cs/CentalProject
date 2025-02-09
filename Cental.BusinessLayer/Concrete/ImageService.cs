using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImageAsync(IFormFile dosya)
        {
            if (dosya != null)
            {
                string dosyaUzantisi = Path.GetExtension(dosya.FileName).ToLower();

                if (dosyaUzantisi == ".jpg" || dosyaUzantisi == ".jpeg" || dosyaUzantisi == ".png")
                {
                    var dosyaAdi = Path.GetFileName(dosya.FileName);
                    var yuklemeYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "adminImage");

                    if (!Directory.Exists(yuklemeYolu))
                    {
                        Directory.CreateDirectory(yuklemeYolu);
                    }

                    var tamYol = Path.Combine(yuklemeYolu, dosyaAdi);

                    // Asenkron olarak dosyayı kaydet
                    using (var dosyaAkisi = new FileStream(tamYol, FileMode.Create))
                    {
                        await dosya.CopyToAsync(dosyaAkisi); // CopyToAsync kullanıldı
                    }

                    return tamYol;
                }
                else
                {
                   return "Lütfen yalnızca .jpg, .jpeg veya .png uzantılı resim dosyaları yükleyin.";
                }
            }
            else
            {
                return "Lütfen bir dosya seçin.";
            }

           
        }
    }
}
