using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class InsertTitileValidator : GameValidator
    {
        public InsertTitileValidator(Context _context) : base(_context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(n => !_context.Title.Any(m => m.Name == n && m.DeleteAt == null))
                .WithMessage("Title already exists");
            });
            RuleFor(x => x.Link).NotEmpty().WithMessage("Link is required").DependentRules(() =>
            {
                RuleFor(x => x.Link).Must(l => !_context.Title.Any(m => m.Link == l && m.DeleteAt == null))
                .WithMessage("Title with that link already exists ");
            });
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required");
            
        }
    }
}
