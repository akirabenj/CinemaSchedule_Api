using Microsoft.AspNetCore.Mvc;
using MovieApp.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService actorService;

        public ActorsController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id)
        {
            var actor = await actorService.GetByIdAsync(id);
            if (actor == null)
                return NotFound();

            return Ok(actor);
        }

        [HttpGet]
        public async Task<IActionResult> GetActorsByMovie(int id)
        {
            var actors = await actorService.GetMovieActorsAsync(id);
            if (actors == null)
                return NotFound();

            return Ok(actors);
        }
    }
}