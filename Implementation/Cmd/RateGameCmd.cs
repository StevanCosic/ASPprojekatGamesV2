using Application.DataTransfer;
using Application.Interfaces;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class RateGameCmd : IRatingTitileCommand
    {
        private readonly Context _context;
        private readonly IApplicationUser _user;
        private readonly RatingValidator _validator;

        public RateGameCmd(Context context, RatingValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 11;

        public string Name =>"Rating Title";

        public void Execute(RatingTitleDto request)
        {
            _validator.ValidateAndThrow(request);

            var rating = new TitileRating
            {
                TitileId = request.titleId,
                UserId = _user.Id,
                Rating = request.Pating
            };

            _context.TitileRatings.Add(rating);
            _context.SaveChanges();
        }
    }
}
