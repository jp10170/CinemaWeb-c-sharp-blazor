using CinemaWeb.Server.Repository;
using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Services
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _repo;
        public ScreeningService(IScreeningRepository repo)
        {
            _repo = repo;
        }
        public async Task<Screening> AddScreening(Screening screening)
        {
            return await _repo.AddScreening(screening);
        }

        public async Task<IEnumerable<ScreeningWeb>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async  Task<ICollection<Screening>> GetScreening()
        {
            return await _repo.GetScreening();
        }

        public async Task<ScreeningWeb> GetScreeningById(int Id)
        {
            return await _repo.GetScreeningById(Id);
        }

        public async Task<Screening> UpdateScreening(Screening screening)
        {
            return await _repo.UpdateScreening(screening);
        }
    }
}
