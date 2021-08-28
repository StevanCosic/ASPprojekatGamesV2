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
    public class GameValidator : AbstractValidator<TitleDto>
    {
        public GameValidator(Context _context)
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
         
            
            
            
            RuleFor(x => x.Year).NotEmpty().WithMessage("Release year is required").DependentRules(() =>
            {
                RuleFor(x => x.Year).InclusiveBetween(1996, DateTime.Now.Year)
                .WithMessage("Year must be between 1996 and current year");
            });
           
            
            
        }
    }

    public class InsertGameCat : AbstractValidator<TitileGenreDto>
    {
        public InsertGameCat(Context _context)
        {
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre is required").DependentRules(() =>
            {
                RuleFor(x => x.GenreId)
                .Must(g => _context.Genres.Any(x => x.Id == g && x.Active == true && x.DeleteAt == null))
                .WithMessage("Genre does't exists in database.");
            });
        }
    }

    public class InsertGameValidator : AbstractValidator<TitileDevDto>
    {
        public InsertGameValidator(Context _context)
        {
            RuleFor(x => x.DevId).NotEmpty().WithMessage("Developer name is required").DependentRules(() =>
            {
                RuleFor(x => x.DevId)
                .Must(a => _context.Devs.Any(x => x.Id == a && x.Active == true && x.DeleteAt == null))
                .WithMessage("Developer does't exists in database.");
            });
        }
    }
}
