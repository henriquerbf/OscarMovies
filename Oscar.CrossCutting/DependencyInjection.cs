using Microsoft.Extensions.DependencyInjection;
using Oscar.Mediator.Commands;
using Oscar.Services;
using System;

namespace Oscar.CrossCutting
{
    public static class DependencyInjection
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
