using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UpdateDevsValidator : DevsValidator
    {
        public UpdateDevsValidator(Context _context) : base(_context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Developer id is requeired").DependentRules(() =>
            {
                RuleFor(x => x.Id).Must(id => _context.Devs.Any(a => a.Id == id && a.DeleteAt == null))
                .WithMessage("Developer doesn't exist");
            });
            
        }
    }
}
