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
    public class InsertDevsValidator : DevsValidator
    {
        public InsertDevsValidator(Context _context) : base(_context)
        {
            RuleFor(x => x.Name)
                .Must((actor, name) => !_context.Devs.Any(a => a.Name == actor.Name))
                .WithMessage("Developer is in database");
        }
    }
}
