using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Actors
{
    public class DevsValidator : AbstractValidator<DevsDto>
    {
        public DevsValidator(Context _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Developer name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name)
                .MinimumLength(5)
                .MaximumLength(50)
                .Matches("^[A-Z][a-z]")
                .WithMessage("Developer name is not in correct format");
            });
          
        }
    }
}
