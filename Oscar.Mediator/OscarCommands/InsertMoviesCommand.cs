using MediatR;
using Oscar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oscar.Mediator.OscarCommands
{
    public class InsertMoviesCommand : IRequest
    {
        public List<JsonMovies> JsonMovies { get; set; }

    }
}
