using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces;
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
    public class GetFavoriteQuery : IGetFavoriteQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IApplicationUser _user;

        public GetFavoriteQuery(Context context, IMapper mapper, IApplicationUser user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }

        public int Id => 23;

        public string Name => "Get favorite titles";

        public PagesResponse<RFavTitleDto> Execute(CommonSearch search)
        {
            var query = _context.UserFavorites
                .Include(x => x.titles)
                .Where(x => x.UserId == _user.Id)
                .AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.TitileId == search.Id);
                if (query == null)
                {
                    throw new EntityNotFoundException(typeof(UserFavorite));
                }
            }

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                var name = search.Name.ToLower();
                query = query.Where(x => x.titles.Name.ToLower().Contains(name));
            }

            var titles = query.Paged<RFavTitleDto, UserFavorite>(search, _mapper);
            
            if (titles.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(UserFavorite));
            }

            return titles;
        }
    }
}
