using Application.DataTransfer;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class InsertGameCmd : IInsertGameCommand
    {
        private readonly Context _context;
        private readonly InsertTitileValidator _validator;
        private readonly IMapper _mapper;
        public InsertGameCmd(Context context, InsertTitileValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Insert new title";

        public void Execute(TitleDto request)
        {
            _validator.ValidateAndThrow(request);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newImageName = guid + extension;

            var movie = new Titles
            {
                Name = request.Name,
                Description = request.Description,
                Year = request.Year,
                Link = request.Link,
                Image = newImageName,
               
            };




            var path = Path.Combine("wwwroot", "images", newImageName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

           

            foreach (var genre in request.genres)
            {
                movie.TitileGenre.Add(new TitileGenre
                {
                    GenreId = genre.GenreId

                   
            });
                _context.SaveChanges();

            }

            foreach (var actor in request.devs)
            {
                movie.TitileDevs.Add(new TitileDevs
                {
                    DevsId = actor.DevId
                });
                _context.SaveChanges();
            }



            _context.Title.Add(movie);
            

            _context.SaveChanges();



          


        }
    }
}
