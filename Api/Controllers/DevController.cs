using Application;
using Application.DataTransfer;
using Application.Interfaces;
using Application.Searches;
using Implementation.Commands;
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
    public class DevController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public DevController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<DevController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommonSearch search,
            [FromServices] GetDevsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<DevController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] DevsDto dto,
            [FromServices] InsertDevCmd command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<DevController>
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] DevsDto dto,
            [FromServices] UpdateDevCmd command)
        {
             _executor.ExecuteCommand(command, dto);
             return StatusCode(204);
        }

        // DELETE api/<DevController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DelDevCmd command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
    }
}
