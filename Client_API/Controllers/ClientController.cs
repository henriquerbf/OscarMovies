using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oscar.Mediator.Controllers;
using Oscar.Mediator.ClientCommands;
using Oscar.Domain.Interfaces;

namespace Client_API.Controllers
{
    [Route("client")]
    [ApiController]
    public class ClientController : BaseController
    {

        [HttpGet][Route("GetMovieById/{Id}")]
        public async Task<IActionResult> GetMovie([FromRoute] int id) =>
            Ok(await Mediator.Send(new SelectMovieCommand { Id = id }));

        [HttpPost][Route("insert")]
        public async Task<IActionResult> GetMovie([FromBody] InsertMovieCommand request) =>
            Ok(await Mediator.Send(request));

    }
}
