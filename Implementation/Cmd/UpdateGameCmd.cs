using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using Implementation.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Implementation.Commands
{
    public class UpdateGameCmd : IUpdateGamesCommand
    {
        private readonly Context _context;
        private readonly UpdateGameValidator _validator;

        public UpdateGameCmd(Context context, UpdateGameValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Update move";

        public void Execute(TitleDto request)
        {
            _validator.ValidateAndThrow(request);

            var titile = _context.Title.Include(x => x.TitileGenre)
                .ThenInclude(x => x.Genre)
                .Include(x => x.TitileDevs)
                .ThenInclude(x => x.Devs)
                .Include(x => x.TitileRatings).FirstOrDefault(x => x.Id == request.Id);
            
            if (request.Image != null)
            {
                var guid = Guid.NewGuid();

                var extension = Path.GetExtension(request.Image.FileName);

                var newImageName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newImageName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    request.Image.CopyTo(fileStream);
                }
                titile.Image = newImageName;
            }
            if(request.CoverImage != null)
            {
                var guid = Guid.NewGuid();

                var extensionCover = Path.GetExtension(request.CoverImage.FileName);

                var newCoverImageName = guid + extensionCover;

                var pathCover = Path.Combine("wwwroot", "images", newCoverImageName);

                using (var fileStream = new FileStream(pathCover, FileMode.Create))
                {
                    request.CoverImage.CopyTo(fileStream);
                }

                
            }

            titile.Name = request.Name;
            titile.Description = request.Description;

            titile.Year = request.Year;
            titile.Link = request.Link;

            foreach (var actorFromReques in request.devs)
            {
                var act = new TitileDevs
                {
                    DevsId = actorFromReques.DevId,
                    TitileId = titile.Id
                };

                if (!titile.TitileDevs.Any(x => x.DevsId == actorFromReques.DevId))
                {
                    titile.TitileDevs.Add(new TitileDevs
                    {
                        DevsId = actorFromReques.DevId
                    });
                }
            }

            foreach (var genreFromReques in request.genres)
            {
                if (!titile.TitileGenre.Any(x => x.GenreId == genreFromReques.GenreId))
                {
                    titile.TitileGenre.Add(new TitileGenre
                    {
                        GenreId = genreFromReques.GenreId
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
