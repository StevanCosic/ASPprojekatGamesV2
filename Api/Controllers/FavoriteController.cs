using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces;
using Application.Searches;
using DataAccess;
using Domain.Entities;
using Implementation.Commands.MovieCommands;
using Implementation.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IApplicationUser _user;
        private readonly UseCaseExecutor _executor;
        private readonly Context _context;

        public FavoriteController(IApplicationUser user, Context context, UseCaseExecutor executor)
        {
            _user = user;
            _context = context;
            _executor = executor;
        }

        // GET: api/<FavoriteController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] CommonSearch search,
            [FromServices] GetFavoriteQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<FavoriteController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] FTitleDto dto,
            [FromServices] FavoriteGameCmd command)
        {
           

                _executor.ExecuteCommand(command, dto);
                return StatusCode(204);
           
        }

        // DELETE api/<UserController>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteFavoriteGameCmd command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }

    }
}
