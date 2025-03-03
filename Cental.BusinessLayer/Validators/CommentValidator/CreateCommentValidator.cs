using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.CommentValidator
{
    public class CreateCommentValidator : AbstractValidator<Review>
    {

        public CreateCommentValidator()
        {
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum Yazma Kısmı Boş Bırakılamaz!");

            RuleFor(x => x.Comment).MinimumLength(5).WithMessage("Yorumunuz En Az 5 Karakterden Oluşmalıdır!");

            RuleFor(x => x.Comment).MaximumLength(100).WithMessage("Yorumunuz En Fazla 100 Karakterden Oluşabilir!");

            RuleFor(x => x.Rating).NotEmpty().WithMessage("Puan Verme Kısmı Boş Bırakılamaz!");
        }
    }
}
