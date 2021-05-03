using MediatR;
using Oscar.Domain.Interfaces;
using Oscar.Domain.Models;
using Oscar.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oscar.Mediator.OscarCommands
{
    public class SelectMoviesCommandHandler : IRequestHandler<SelectMoviesCommand, Movie>
    {
        private readonly IMovieService _movieService;

        public SelectMoviesCommandHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public Task<Movie> Handle(SelectMoviesCommand request, CancellationToken cancellationToken)
        {
            return _movieService.Select(request.Id);
        }
    }
}
