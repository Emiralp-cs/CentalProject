using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.CarDtos
{
    public class CreateCarDto
    {

        public string? ModelName { get; set; }
        public string? ImageUrl { get; set; }
        public int Price { get; set; }
        public int SeatCount { get; set; }
        public string? GearType { get; set; }
        public string? GasType { get; set; }
        public int Year { get; set; }

        public string? Transmission { get; set; }
        public int Kilometer { get; set; }
        [Required(ErrorMessage = "Marka boş bırakılamaz!")]
        public int BrandId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Resim boş bırakılamaz!")]
        public IFormFile ImageFile { get; set; }


    }
}
