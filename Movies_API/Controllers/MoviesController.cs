using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oscar.Mediator.Controllers;
using Oscar.Mediator.OscarCommands;

namespace Oscar_API.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MoviesController : BaseController
    {
        
        [HttpPost][Route("insert")]
        public async Task<IActionResult> Insert([FromBody] InsertMoviesCommand request) =>
            Ok(await Mediator.Send(request));

        
        [HttpGet][Route("select/{Id}")]
        public async Task<IActionResult> Select([FromRoute] int id) =>
            Ok(await Mediator.Send(new SelectMoviesCommand { Id = id }));

    }
}
