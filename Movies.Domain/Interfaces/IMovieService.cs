﻿using Oscar.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oscar.Services
{
    public interface IMovieService
    {
        Task Insert(List<Movie> movies);
        Task<Movie> Select(int id);
    }
}