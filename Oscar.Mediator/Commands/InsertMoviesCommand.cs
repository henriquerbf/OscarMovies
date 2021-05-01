using MediatR;
using Oscar.Mediator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oscar.Mediator.Commands
{
    public class InsertMoviesCommand : IRequest
    {
        public List<JsonMovies> jsonMovies { get; set; }

    }
}
