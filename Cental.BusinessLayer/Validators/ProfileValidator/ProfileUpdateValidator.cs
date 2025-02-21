using Cental.DTOLayer.UserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.ProfileUpdateValidator
{
    public class ProfileUpdateValidator : AbstractValidator<ProfileEditDto>
    {
        public ProfileUpdateValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta Boş Bırakılamaz!");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad Boş Bırakılamaz!");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad Boş Bırakılamaz!");

            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Şifre Boş Bırakılamaz!");
        }
    }
}
