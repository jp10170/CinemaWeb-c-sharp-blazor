using CinemaWeb.Server.Data;
using CinemaWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Repository
{
    public class ScreeningRepository: IScreeningRepository
    {
        private readonly ApplicationDbContext _context;
        public ScreeningRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Screening> AddScreening(Screening screening)
        {
            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();
            return screening;
        }

        public  async Task<IEnumerable<ScreeningWeb>> GetAll()
        {
            var res= from s in _context.Screenings.Where(x => x.Screening_start > DateTime.Now)
                   select new ScreeningWeb
                   {
                        Id= s.Id,
                        Screening_start = s.Screening_start,
                        Movie = s.Movie.Movie_Name,
                        Hall = s.Hall.Name,
                   };
            return await res.ToListAsync();
        }

        public async Task<ICollection<Screening>> GetScreening()
        {
            return await _context.Screenings.ToListAsync();
        }

        public async Task<ScreeningWeb> GetScreeningById(int Id)
        {

            var scr = await _context.Screenings.FirstOrDefaultAsync(a => a.Id == Id);
                string hname = _context.Halls.FirstOrDefault(x => x.Id == scr.HallId).Name;
                string mname = _context.Movies.FirstOrDefault(x => x.Id == scr.MovieId).Movie_Name;
                ScreeningWeb sw = new ScreeningWeb
                {
                    Screening_start = scr.Screening_start,
                    Hall = hname,
                    Movie = mname,
                    Id = scr.Id
                };
            return sw;
        }

        public async Task<Screening> UpdateScreening(Screening screening)
        {
            _context.Entry(screening).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return screening;
        }
    }
}
