using Cental.DTOLayer.CarDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.CarValidator
{
    public class CreateCarValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty()
                .WithMessage("Araba modeli boş bırakılamaz!")
                .MinimumLength(3).WithMessage("Araba modeli en az 3 karakterden oluşmalıdır!");


            RuleFor(x => x.Transmission).NotEmpty().WithMessage("Vites Özelliği Boş Bırakılamaz!");
            RuleFor(x => x.GasType).NotEmpty().WithMessage("Yakıt Türü Boş Bırakılamaz!");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("Vites Türü Boş Bırakılamaz!");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Marka Boş Bırakılamaz!");


            RuleFor(x => x.GasType).NotEmpty()
               .WithMessage("Yakıt türü boş bırakılamaz!");

            RuleFor(x => x.Price).NotEmpty()
              .WithMessage("Kiralama Bedeli Boş Bırakılamaz!");

            RuleFor(x => x.Kilometer).NotEmpty()
               .WithMessage("Kilometre Boş Bırakılamaz!");

            RuleFor(x => x.GearType).NotEmpty()
              .WithMessage("Vites türü boş bırakılamaz!");

            RuleFor(x => x.SeatCount).NotEmpty()
              .WithMessage("Yakıt türü boş bırakılamaz!");


            RuleFor(x => x.Year).NotEmpty()
                .WithMessage("Yıl boş bırakılamaz!");

            

        }
    }
}
