using Microsoft.AspNetCore.Mvc;
using Application;
using Application.DataTransfer;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Application.Searches;
using Implementation.Commands;
using Implementation.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public GameController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<GameController>
        [HttpGet]
        public IActionResult Get([FromQuery] GamesSearch search,
            [FromServices] GetGamesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<GameController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] TitleDto dto,
            [FromServices] InsertGameCmd command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<GameController>
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromForm] TitleDto dto,
            [FromServices] UpdateGameCmd command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteGameCmd command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
    }
}
