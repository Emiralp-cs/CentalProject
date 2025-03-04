using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.ContactValidator
{
    public class CreateContactValidator : AbstractValidator<Contact>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad Boş Bırakılamaz!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta Boş Bırakılamaz!");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Bırakılamaz!");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Boş Bırakılamaz!");
        }
    }
}
