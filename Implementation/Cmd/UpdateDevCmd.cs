using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Commands;
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
    public class UpdateDevCmd : IInsertDevCommand
    {
        private readonly Context _context;
        private readonly UpdateDevsValidator _validator;

        public UpdateDevCmd(Context context, UpdateDevsValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Update Dev";

        public void Execute(DevsDto request)
        {
            _validator.ValidateAndThrow(request);

            var actor = _context.Devs.FirstOrDefault(x => x.Id == request.Id);

            actor.Name = request.Name;
            

            _context.SaveChanges();

        }
    }
}
