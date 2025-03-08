using Cental.DTOLayer.BaseDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.AboutDtos
{
    public class CreateAboutDto : BaseDto
    {
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public int ExperienceYear { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
        public string NameSurname { get; set; }
        public string JobTitle { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsShow { get; set; }
        public IFormFile ImageFile1 { get; set; }
        public IFormFile ImageFile2 { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
    }
}
