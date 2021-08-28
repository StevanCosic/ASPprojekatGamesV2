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
    public class DevsProfile : Profile
    {
        public DevsProfile()
        {
            CreateMap<Devs, RDevsDto>()
                .ForMember(x => x.GameDevsGenDto, y => y.MapFrom(movie => movie.TitileDevs.Select(m => 
                new GameDevsGenDto
                { 
                    Id = m.Titles.Id,
                    Name = m.Titles.Name
                })));
            CreateMap<DevsDto, Devs>();

        }
    }
}
