using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Game
{
    public class FavValidator : AbstractValidator<FTitleDto>
    {
        public FavValidator(Context _context)
        {
            RuleFor(x => x.GameId).NotEmpty().WithMessage("TitileId is required").DependentRules(() =>
                {
                    RuleFor(x => x.GameId).Must(x => _context.Title.Any(y => y.Id == x && y.DeleteAt == null))
                   .WithMessage("Titile doesn't exist");

                    

                });



        } 



        }




    }

