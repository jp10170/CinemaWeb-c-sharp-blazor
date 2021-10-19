using CinemaWeb.Server.Data;
using CinemaWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Repository
{
    public class SeatnoRepository:ISeatnoRepository
    {
        private readonly ApplicationDbContext _context;
        public SeatnoRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Seatno> AddSeatno(Seatno seatno)
        {
            _context.Seatnos.Add(seatno);
            await _context.SaveChangesAsync();
            return seatno;
        }

        public async Task<ICollection<Seatno>> GetSeatnos()
        {
            return await _context.Seatnos.ToListAsync();
        }
        public async Task<Seatno> GetSeatnoById(int Id)
        {
            var seat = await _context.Seatnos.FirstOrDefaultAsync(m => m.Id == Id);
            return seat;

        }


        public async Task<IEnumerable<SeatWeb>> AvailableSeats(int Id)
        {
            var res= from s in _context.Seatnos.FromSqlRaw(@"SELECT 
	                                                                sn.Id,
                                                                    sn.Number,
                                                                    sn.HallId
                                                                FROM[Cinema].[dbo].[Screenings] s
                                                                join Seatnos sn
                                                                on sn.HallId = s.HallId
                                                                left join Bookings b
                                                                on b.ScreeningId = s.Id and b.SeatnoId = sn.Id
                                                                where b.Id IS NULL and s.Id = " + Id)
                      select new SeatWeb
                      {
                          Id = s.Id,
                          Number = s.Number,
                          HallId = s.HallId
                      };
            return await res.ToListAsync();
        }
    }
}
