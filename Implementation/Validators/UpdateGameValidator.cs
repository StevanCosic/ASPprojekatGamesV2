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
    public class UpdateGameValidator : GameValidator
    {
        public UpdateGameValidator(Context _context) : base(_context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Title id is requeired").DependentRules(() => 
            {
                RuleFor(x => x.Id).Must(id => _context.Title.Any(m => m.Id == id && m.DeleteAt == null))
                .WithMessage("Title doesn't exist");
            });
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name)
                .Must((movie, n) => !_context.Title.Any(m => m.Name == n && m.Id != movie.Id && m.DeleteAt == null))
                .WithMessage("Title exists in database");
            });

            RuleFor(x => x.Link).NotEmpty().WithMessage("Link is required").DependentRules(() =>
            {
                RuleFor(x => x.Link)
                .Must((movie, l) => !_context.Title.Any(m => m.Link == l && m.Id != movie.Id && m.DeleteAt == null))
                .WithMessage("Title with that link already exists");
            });
        }
    }
}
