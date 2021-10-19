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
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service= service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movs = await _service.GetMovies();
            return Ok(movs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int Id)
        {
            Movie mov = await _service.GetMovieById(Id);
            return Ok(mov);
        }
        [HttpPost]

        public async Task<IActionResult> AddMovie(Movie movie)
        {
            await _service.AddMovie(movie);
            return Ok(movie);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            await _service.UpdateMovie(movie);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteMovie(id);
            return NoContent();
        }
        
    }
}
