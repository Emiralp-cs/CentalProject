using Cental.DTOLayer.CarDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.CarValidator
{
    public class UpdateCarValidator : AbstractValidator<UpdateCarDto>
    {
        public UpdateCarValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty()
               .WithMessage("Araba modeli boş bırakılamaz!")
               .MinimumLength(3).WithMessage("Araba modeli en az 3 karakterden oluşmalıdır!");
            RuleFor(x => x.Transmission).NotEmpty()
               .WithMessage("Vites türü boş bırakılamaz!")
               .MinimumLength(3).WithMessage("Vites türü en az 3 karakterden oluşmalıdır!");
            RuleFor(x => x.GasType).NotEmpty()
               .WithMessage("Yakıt türü boş bırakılamaz!")
               .MinimumLength(3).WithMessage("Yakıt türü en az 3 karakterden oluşmalıdır!");
            RuleFor(x => x.Price).NotEmpty()
              .WithMessage("Yakıt türü boş bırakılamaz!");
            RuleFor(x => x.Kilometer).NotEmpty()
               .WithMessage("Yakıt türü boş bırakılamaz!");
            RuleFor(x => x.GearType).NotEmpty()
              .WithMessage("Vites türü boş bırakılamaz!")
              .MinimumLength(3).WithMessage("Yakıt türü en az 3 karakterden oluşmalıdır!");
            RuleFor(x => x.SeatCount).NotEmpty()
              .WithMessage("Yakıt türü boş bırakılamaz!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş bırakılamaz!");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Yıl boş bırakılamaz!");
        }
    }
}
