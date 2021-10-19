﻿using CinemaWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Server.Repository
{
    public interface IScreeningRepository
    {
        Task<ICollection<Screening>> GetScreening();
        Task<ScreeningWeb> GetScreeningById(int Id);
        Task<IEnumerable<ScreeningWeb>> GetAll();
        Task<Screening> AddScreening(Screening screening);
        Task<Screening> UpdateScreening(Screening screening);
    }
}
