using MediatR;
using Oscar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oscar.Mediator.Commands
{
    public class SelectMoviesCommand : IRequest<Movie>
    {
        public int Id;
    }
}
