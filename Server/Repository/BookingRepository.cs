using CinemaWeb.Server.Data;
using CinemaWeb.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Repository
{
    public class BookingRepository:IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<ICollection<Booking>> GetBooking()
        {
            return await _context.Bookings.ToListAsync();
        }
        public async Task<Booking> GetBookingById(int Id)
        {
            var bok = await _context.Bookings.FirstOrDefaultAsync(m => m.Id == Id);
            return bok;

        }
        public async Task<Booking> AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<IEnumerable<BookingWeb>> GetAll()
        {
            var res = from s in _context.Bookings
                      select new BookingWeb
                      {
                          Id = s.Id,
                          SeatNumber= s.Seatno.Number,
                          User_Name = s.User_Name,
                          Movie=s.Screening.Movie.Movie_Name,
                          Hall_Name=s.Screening.Hall.Name,
                          Screening_start=s.Screening.Screening_start,
                      };
            return await res.ToListAsync();
        }
    }
}
