using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class ReviewTitleCmd : IRevewTitle
    {
        private readonly Context _context;
        private readonly IApplicationUser _user;
        private readonly ReviewValidator _validator;
        private readonly IMapper _mapper;

        public ReviewTitleCmd(Context context, ReviewValidator validator, IMapper mapper, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _user = user;
        }
        public int Id => 10;

        public string Name => "Comment movie";

        public void Execute(ReviewDto request)
        {
            _validator.ValidateAndThrow(request);

            var com = new TitleReview
                {
                    TitileId = request.IdTitle,
                    UserId = _user.Id,
                    Review = request.Review,
                    ReviewDate = DateTime.Now
                };

            _context.TitleReviews.Add(com);
            _context.SaveChanges();
        }
    }
}
