using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.TopBarValidator
{
    public class TopBarValidator : AbstractValidator<TopBar>
    {
        public TopBarValidator()
        {
            RuleFor(x => x.Location).NotEmpty().WithMessage("Lokasyon Boş Bırakılamaz!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Bırakılamaz!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-Posta Boş Bırakılamaz!")
                .EmailAddress().WithMessage("Geçerli Bir E-posta Adresi Girin");
            RuleFor(x => x.Facebook).NotEmpty().WithMessage("Facebook Url Boş Bırakılamaz!");
            RuleFor(x => x.Twitter).NotEmpty().WithMessage("Twitter Url Boş Bırakılamaz!");
            RuleFor(x => x.Instagram).NotEmpty().WithMessage("Instagram Url Boş Bırakılamaz!");
            RuleFor(x => x.Linkedln).NotEmpty().WithMessage("Linkedln Url Boş Bırakılamaz!");


        }
    }
}
