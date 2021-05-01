using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oscar.Services;
using Oscar.Domain.Models;
using Oscar.Mediator.Models;
using Oscar.Mediator.Commands;

namespace Oscar_API.Controllers
{
    [Route("Movies")]
    [ApiController]
    public class MoviesController : BaseController
    {
        [Route("insert")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertMoviesCommand request) =>
            Ok(await Mediator.Send(request));

        [Route("select/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Select([FromRoute] int id) =>
            Ok(await Mediator.Send(new SelectMoviesCommand { Id = id }));

    }
}
