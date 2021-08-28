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
    public class GetGamesQuery : IGetGameQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetGamesQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 17;

        public string Name => "Search titles";

        public PagesResponse<RTitleDto> Execute(GamesSearch search)
        {
            var query = _context.Title.Include(x => x.TitileGenre)
                .ThenInclude(x => x.Genre)
                .Include(x => x.TitileDevs)
                .ThenInclude(x => x.Devs)
                .Include(x => x.TitileRatings)
                .Include(x => x.TitleReviews)
                .ThenInclude(x => x.User)
                .Where(x => x.Active == true && x.DeleteAt == null)
                .AsQueryable();

            if (search.Id.HasValue)
            {
                query = query.Where(x => x.Id == search.Id);
                if (query == null)
                {
                    throw new EntityNotFoundException(typeof(Titles));
                }
            }

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                var name = search.Name.ToLower();
                query = query.Where(x =>
                                    x.Name.ToLower().Contains(name) ||
                                    x.Description.ToLower().Contains(name) ||
                                    x.TitileDevs.Any(a => a.Devs.Name.ToLower().Contains(name)) ||
                                    x.TitileGenre.Any(g => g.Genre.Name.ToLower().Contains(name)));
            }

            if (search.MinYear.HasValue)
            {
                query = query.Where(x => x.Year >= search.MinYear);
            }

            if (search.MaxYear.HasValue)
            {
                query = query.Where(x => x.Year <= search.MaxYear);
            }

            

            if (search.MinRating.HasValue)
            {
                query = query.Where(x => x.TitileRatings.Average(y => y.Rating) >= search.MinRating);
            }

            if (search.MaxRating.HasValue)
            {
                query = query.Where(x => x.TitileRatings.Average(y => y.Rating) <= search.MaxRating);
            }

            var movies = query.Paged<RTitleDto, Titles>(search, _mapper);
            if(movies.Items.Count() == 0)
            {
                throw new EntityNotFoundException(typeof(Titles));
            }

            return movies;
        }
    }
}
