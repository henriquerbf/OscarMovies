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
    public class InsertMoviesCommandHandler : IRequestHandler<InsertMoviesCommand, Unit>
    {
        private readonly IMovieService _movieService;

        public InsertMoviesCommandHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<Unit> Handle(InsertMoviesCommand request, CancellationToken cancellationToken)
        {
            var movies = new List<Movie>();

            var studio = new Studio
            {
                Name = "Marvel"
            };

            foreach (var item in request.JsonMovies)
            {
                movies.Add(new Movie
                {
                    Id_Received = item.Id,
                    Title = item.Title,
                    Release_Date = item.Release_Date,
                    Studio = studio
                });
            }

            await _movieService.Insert(movies);

            return Unit.Value;
        }
    }
}
