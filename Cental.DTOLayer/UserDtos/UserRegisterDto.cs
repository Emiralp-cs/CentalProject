using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.UserDtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Email Boş Bırakılamaz!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad Boş Bırakılamaz!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad Boş Bırakılamaz!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Şifre Bırakılamaz!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler birbiri ile uyumlu değil!")]
        [Required(ErrorMessage = "Şifre Doğrulama Bırakılamaz!")]
        public string ConfirmPassword { get; set; }
    }
}
