using MediatR;
using Oscar.Domain.Interfaces;
using Oscar.Domain.Models;
using Oscar.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oscar.Mediator.ClientCommands
{
    public class InsertMovieCommandHandler : IRequestHandler<InsertMovieCommand, Unit>
    {
        private readonly IOscarService _oscarService;

        public InsertMovieCommandHandler(IOscarService oscarService)
        {
            _oscarService = oscarService;
        }

        public async Task<Unit> Handle(InsertMovieCommand request, CancellationToken cancellationToken)
        {
            var studio = new Studio
            {
                Name = "Marvel"
            };

            Movie movie = new Movie
            {
                Id_Received = request.Id,
                Title = request.Title,
                Release_Date = request.Release_Date,
                Studio = studio
            };

            await _oscarService.InsertMovie(movie);

            return Unit.Value;
        }
    }
}
