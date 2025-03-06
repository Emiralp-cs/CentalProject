using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.ServicesValidator
{
    public class UpdateServicesValidator : AbstractValidator<Service>
    {
        public UpdateServicesValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon Boş Bırakılamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz!");
        }
    }
}
