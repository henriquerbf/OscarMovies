using MediatR;
using Oscar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oscar.Mediator.ClientCommands
{
    public class SelectMovieCommand : IRequest<Movie>
    {
        public int Id;
    }
}
