using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Services
{
    public interface ISeatnoService
    {
        Task<IEnumerable<SeatWeb>> AvailableSeats(int Id);
        Task<Seatno> GetSeatnoById(int Id);
        Task<ICollection<Seatno>> GetSeatnos();
        Task<Seatno> AddSeatno(Seatno seatno);
    }
}
