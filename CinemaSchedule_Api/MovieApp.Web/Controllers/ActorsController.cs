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
            return Ok(await actorService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetActorsByMovie(int id)
        {
            return Ok(await actorService.GetMovieActors(id));
        }
    }
}