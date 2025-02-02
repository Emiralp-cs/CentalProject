﻿using Cental.DTOLayer.BannerDtos;
using Cental.DTOLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class BrandValidator : AbstractValidator<CreateBrandDTO>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("Marka ismi boş bırakılamaz!")
                .MinimumLength(3).WithMessage("Marka ismi en az 3 karakter olmalıdır!");
                 
        }
    }
}
