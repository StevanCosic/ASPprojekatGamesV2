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
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Titles, RTitleDto>()
                .ForMember(x => x.Devs, y => y.MapFrom(actor => actor.TitileDevs.Select(a => 
                new DevsDto
                {
                    Id = a.Devs.Id,
                    Name = a.Devs.Name,
                   
                })))
                .ForMember(x => x.Genres, y => y.MapFrom(genre => genre.TitileGenre.Select(g =>
                new GenreDto
                {
                    Id = g.Genre.Id,
                    Name = g.Genre.Name
                })))
                .ForMember(x => x.Reviews, y => y.MapFrom(com => com.TitleReviews.Select(c =>
                new ReviewCommandDto
                {
                    UserName = c.User.Username,
                    Reviews = c.Review,
                    Date = c.ReviewDate
                })))
                .ForMember(x => x.Rating, y => y.MapFrom(rating => rating.TitileRatings.Any(r => r.Titles == rating) ? rating.TitileRatings.Average(r =>r.Rating).ToString() : "This title does not have rating yet"));
        }
    }
}
