using Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Oscar.Domain.Interfaces;
using Oscar.Services;
using System;

namespace Oscar.CrossCutting
{
    public static class DependencyInjection
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IOscarService, OscarService>();
        }
    }
}
