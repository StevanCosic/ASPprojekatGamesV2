using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class RatingValidator : AbstractValidator<RatingTitleDto>
    {
        public RatingValidator(Context _context)
        {
            RuleFor(x => x.titleId).NotEmpty().WithMessage("Titile is required").DependentRules(() =>
            {
                RuleFor(x => x.titleId).Must(x => _context.Title.Any(y => y.Id == x && y.DeleteAt == null))
                .WithMessage("Titile doesn't exist");
            });
            RuleFor(x => x.Pating).NotEmpty().WithMessage("Rating is required").DependentRules(() =>
            {
                RuleFor(x => x.Pating).InclusiveBetween(1, 10)
                .WithMessage("Titile rating must be between 1 and 10");
            });
        }
    }
}
