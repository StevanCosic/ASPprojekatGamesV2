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
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator(Context _context)
        {
            RuleFor(x => x.IdTitle).NotEmpty().WithMessage("Title is required").DependentRules(() =>
            {
                RuleFor(x => x.IdTitle).Must(x => _context.Title.Any(y => y.Id == x && y.DeleteAt == null))
                .WithMessage("Title doesn't exist");
            });
            RuleFor(x => x.Review).NotEmpty().WithMessage("Review is required");
        }
    }
}
