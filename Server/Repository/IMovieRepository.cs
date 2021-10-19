using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Repository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMovies();
        Task<Movie>  GetMovieById(int movieId);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> AddMovie(Movie Movie);
        Task<Movie> DeleteMovie(int movieId);
    }
}
