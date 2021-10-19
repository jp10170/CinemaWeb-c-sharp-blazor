using CinemaWeb.Server.Data;
using CinemaWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Repository
{
    public class MovieRepository:IMovieRepository 
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<ICollection<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }
        public async Task<Movie> GetMovieById(int Id)
        {
            var mov = await _context.Movies.FirstOrDefaultAsync(m => m.Id == Id);
            return mov;

        }
        public async Task<Movie> UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task<Movie> DeleteMovie(int id)
        {
            var mov = new Movie { Id = id };
            _context.Remove(mov);
            await _context.SaveChangesAsync();
            return mov;
        }
        

    }
}
