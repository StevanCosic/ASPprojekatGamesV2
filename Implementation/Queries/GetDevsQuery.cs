using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Queries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetDevsQuery : IGetDevQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetDevsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Get Developers";

        public PagesResponse<RDevsDto> Execute(CommonSearch search)
        {
            var query = _context.Devs
                .Include(x => x.TitileDevs)
                .ThenInclude(y => y.Titles)
                .Where(x => x.Active == true && x.DeleteAt == null)
                .AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
                if (query == null){
                    throw new EntityNotFoundException(typeof(Devs));
                }
            }

            if (!string.IsNullOrEmpty(search.Name))
            {
                var name = search.Name.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(name));
            }

            var devs = query.Paged<RDevsDto, Devs>(search, _mapper);
            if (devs.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Devs));
            }
            return devs;
        }
    }
}
