using Cental.DTOLayer.BookingDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.BookingCarValidator
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.DropOffLocation).NotEmpty().WithMessage("Boş Bırakılamaz!");
            RuleFor(x => x.PickUpLocation).NotEmpty().WithMessage("Boş Bırakılamaz!");
            RuleFor(x => x.DropOffDate).NotEmpty().WithMessage("Bitiş Tarihi Boş Bırakılamaz!");
            RuleFor(x => x.PickUpDate).NotEmpty().WithMessage("Başlangıç Tarihi Boş Bırakılamaz!");

        }
    }
}
