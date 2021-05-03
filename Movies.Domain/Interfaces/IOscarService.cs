using Oscar.Domain.Models;
using System.Threading.Tasks;

namespace Oscar.Domain.Interfaces
{
    public interface IOscarService
    {
        Task<Movie> GetMovieById(int id);
        Task<Movie> InsertMovie(Movie movie);
    }
}