using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.UserDtos
{
    public class ProfileEditDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AdminProfileImageUrl { get; set; }
        public IFormFile AdminProfileImageFile { get; set; }
        public string CurrentPassword { get; set; }
      
    }
}
