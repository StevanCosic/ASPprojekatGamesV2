using Application.DataTransfer;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, RGenreDTO>()
                .ForMember(x => x.GameDevsGens, y => y.MapFrom(movie => movie.TitileGenre.Select(m => new GameDevsGenDto 
                { 
                    Id = m.title.Id,
                    Name = m.title.Name
                })));
            CreateMap<GenreDto, Genre>();
        }
    }
}
