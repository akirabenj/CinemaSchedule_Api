using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.BL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController<T> : Controller
    {
        private readonly IMovieService movieService;
        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        //GetById
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await movieService.GetById(id);
            if (result == null)
                return BadRequest();
            else
                return Ok(result);
        }

        [HttpGet("getbydate")]
        public async Task<IActionResult> GetByDate(string _date)
        {
            var result = await movieService.GetMoviesByDate(_date);
            if (result == null)
                return BadRequest();
            else
                return Ok(result);
        }
    }

}