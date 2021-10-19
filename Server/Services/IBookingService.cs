using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Services
{
    public interface IBookingService
    {
        Task<ICollection<Booking>> GetBooking();
        Task<Booking> GetBookingById(int Id);
        Task<Booking> AddBooking(Booking booking);
        Task<IEnumerable<BookingWeb>> GetAll();

    }
}
