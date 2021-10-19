using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWeb.Server.Data;
using CinemaWeb.Server.Repository;
using CinemaWeb.Server.Services;
using CinemaWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        public BookingController(IBookingService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boks = await _service.GetBooking();
            return Ok(boks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var bok = await _service.GetBookingById(Id);
            return Ok(bok);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Booking booking)
        {
            await _service.AddBooking(booking);
            return Ok(booking);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAll();
            return Ok(res);
        }
    }
}

