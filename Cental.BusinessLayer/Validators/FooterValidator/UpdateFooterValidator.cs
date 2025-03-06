using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.FooterValidator
{
    public class UpdateFooterValidator : AbstractValidator<Footer>
    {
        public UpdateFooterValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz!");
        }


    }
}
