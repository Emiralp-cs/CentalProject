using Cental.DTOLayer.BrandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.BrandValidator
{
    public class UpdateBrandValidator : AbstractValidator<UpdateBrandDTO>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty()
                .WithMessage("Marka ismi boş bırakılamaz!")
                .MinimumLength(3).WithMessage("Marka ismi en az 3 karakter olmalıdır!");


        }
    }
}
