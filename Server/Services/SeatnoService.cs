using CinemaWeb.Server.Repository;
using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Services
{
    public class SeatnoService : ISeatnoService
    {
        private readonly ISeatnoRepository _repo;
        public SeatnoService(ISeatnoRepository repo)
        {
            _repo = repo;
        }
        public async Task<Seatno> AddSeatno(Seatno seatno)
        {
            return await _repo.AddSeatno(seatno);
        }

        public async Task<IEnumerable<SeatWeb>> AvailableSeats(int Id)
        {
            return await _repo.AvailableSeats(Id);
        }

        public async Task<Seatno> GetSeatnoById(int Id)
        {
            return await _repo.GetSeatnoById(Id);
        }

        public async Task<ICollection<Seatno>> GetSeatnos()
        {
            return await _repo.GetSeatnos();
        }
    }
}
