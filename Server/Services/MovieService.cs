using CinemaWeb.Server.Repository;
using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }
        public async Task<Movie> AddMovie(Movie Movie)
        {
            return await _repo.AddMovie(Movie);
        }

        public async Task<Movie> DeleteMovie(int movieId)
        {
            return await _repo.DeleteMovie(movieId);
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            return await _repo.GetMovieById(movieId);
        }

        public async Task<ICollection<Movie>> GetMovies()
        {
            return await _repo.GetMovies();
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            return await _repo.UpdateMovie(movie);
        }
    }
}
