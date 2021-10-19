using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    public class ScreeningController : ControllerBase
    {
        
        private readonly IScreeningService _service;
        public ScreeningController(IScreeningService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var scrs = await _service.GetScreening();
            return Ok(scrs);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var res= await _service.GetAll();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var sw = await _service.GetScreeningById(Id);
            return Ok(sw);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Screening screening)
        {
            var res = await _service.AddScreening(screening);
            return Ok(res);
        }
        
    }
}
