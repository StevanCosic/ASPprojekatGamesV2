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
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<UserFavorite, RFavTitleDto>()
                .ForMember(x => x.IdGame, y => y.MapFrom(movie => movie.titles.Id))
                .ForMember(x => x.Name, y => y.MapFrom(movie => movie.titles.Name))
                .ForMember(x => x.Image, y => y.MapFrom(movie => movie.titles.Image))
                .ForMember(x => x.Year, y => y.MapFrom(movie => movie.titles.Year));
        }
    }
}
