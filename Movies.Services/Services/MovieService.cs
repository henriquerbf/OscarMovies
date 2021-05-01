using Microsoft.Extensions.Configuration;
using System;
using Oscar.Domain.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace Oscar.Services
{
    public class MovieService : IMovieService
    {
        private readonly IConfiguration _configuration;

        public MovieService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Insert(List<Movie> movies)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Docker")))
            {
                foreach (var movie in movies)
                {
                    var par = new DynamicParameters();

                    par.Add("@Title", movie.Title);
                    par.Add("@Release_Date", movie.Release_Date);
                    par.Add("@Id_Received", movie.Id_Received);
                    await connection.ExecuteAsync("insert into movies(Title, Release_Date, Id_Received) values (@Title, @Release_Date, @Id_Received)", par);
                }

            }
        }
        public async Task<Movie> Select(int id)
        {
            string sql = "SELECT * FROM Movies WHERE Id = @Id";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("Docker")))
            {
                var par = new DynamicParameters();
                par.Add("@Id", id);

                return await connection.QuerySingleOrDefaultAsync<Movie>(sql, par);
            }
        }
    }
}
