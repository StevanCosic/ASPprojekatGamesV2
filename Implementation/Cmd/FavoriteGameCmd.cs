using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands.MovieCommands;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.MovieCommands
{
    public class FavoriteGameCmd : IFavoriteGamesCommand
    {
        private readonly Context _context;
        private readonly FavValidator _validator;
        private readonly IApplicationUser _user;

        public FavoriteGameCmd(Context context, FavValidator validator, IApplicationUser user)
        {
            _context = context;
            _user = user;
            _validator = validator;
        }

        public int Id => 20;

        public string Name => "Favorite title";

        public void Execute(FTitleDto request)
        {
           
            _validator.ValidateAndThrow(request);

            var favorite = new UserFavorite
            {
                UserId = _user.Id,
                TitileId = request.GameId
            };

            _context.UserFavorites.Add(favorite);
            _context.SaveChanges();
        }
    }
}
