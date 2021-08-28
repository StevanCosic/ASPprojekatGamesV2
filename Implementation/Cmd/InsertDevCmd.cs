using Application.DataTransfer;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using Implementation.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class InsertDevCmd : IInsertDevCommand
    {
        private readonly Context _context;
        private readonly InsertDevsValidator _validator;
        private readonly IMapper _mapper;

        public InsertDevCmd(Context context, InsertDevsValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Insert new Developer";

        public void Execute(DevsDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Devs.Add(_mapper.Map<Devs>(request));

            _context.SaveChanges();
        }
    }
}
