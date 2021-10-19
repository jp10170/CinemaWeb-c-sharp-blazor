using CinemaWeb.Server.Repository;
using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;
        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }
        public async Task<Booking> AddBooking(Booking booking)
        {
            return await _repo.AddBooking(booking);
        }

        async public Task<IEnumerable<BookingWeb>> GetAll()
        {
            return await _repo.GetAll();
        }

        async public Task<ICollection<Booking>> GetBooking()
        {
            return await _repo.GetBooking();
        }

        async public Task<Booking> GetBookingById(int Id)
        {
            return await _repo.GetBookingById(Id);
        }
    }
}
