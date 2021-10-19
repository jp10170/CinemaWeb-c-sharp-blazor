using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaWeb.Server.Data;
using CinemaWeb.Shared.Models;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using CinemaWeb.Server.Repository;
using CinemaWeb.Server.Services;

namespace CinemaWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatnoesController : ControllerBase
    {
        private readonly ISeatnoService _service;

        public SeatnoesController(ISeatnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var seats = await _service.GetSeatnos();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatnoById(int Id)
        {
            Seatno seatno = await _service.GetSeatnoById(Id);
            return Ok(seatno);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeatno(Seatno seatno)
        {
            await _service.AddSeatno(seatno);
            return Ok(seatno);
        }
        [HttpGet("AvailableSeats/{id}")]
        public async Task<IActionResult> AvailableSeats(int Id)
        {

            var res = await _service.AvailableSeats(Id);
            return Ok(res);

        }

       
    }
}
