using Application;
using Application.DataTransfer;
using Application.Interfaces;
using Implementation.Commands;
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
    public class ReviewController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ReviewController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // POST api/<ReviewController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] ReviewDto dto,
            [FromServices] ReviewTitleCmd command)
        {
             _executor.ExecuteCommand(command, dto);
             return StatusCode(204);
        }

    }
}
