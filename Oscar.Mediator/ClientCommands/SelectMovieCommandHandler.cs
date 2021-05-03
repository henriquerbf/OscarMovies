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
    public class SelectMovieCommandHandler : IRequestHandler<SelectMovieCommand, Movie>
    {
        private readonly IOscarService _oscarService;

        public SelectMovieCommandHandler(IOscarService oscarService)
        {
            _oscarService = oscarService;
        }

        public Task<Movie> Handle(SelectMovieCommand request, CancellationToken cancellationToken)
        {
            return _oscarService.GetMovieById(request.Id);
        }
    }
}
