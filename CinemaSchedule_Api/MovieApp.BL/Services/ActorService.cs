using Microsoft.EntityFrameworkCore;
using MovieApp.BL.DTO;
using MovieApp.BL.Infrastructure;
using MovieApp.BL.Interfaces;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.BL.Services
{
    public class ActorService : IActorService
    {
        private readonly MovieAppContext Context;
        public ActorService(MovieAppContext context)
        {
            Context = context;
        }

        public async Task<ActorDTO> GetByIdAsync(int id)
        {
            var result = await Context.Actors.FindAsync(id);
            if (result == null)
                throw new NotFoundException(nameof(Actor));
            var actor = new ActorDTO
            {
                Id = result.Id,
                Name = result.Name
            };
            return actor;
        }

        public async Task<IEnumerable<ActorDTO>> GetMovieActorsAsync(int id)
        {
            var result = await Context.Actors
                .Where(a => a.ActorMovies.Any(am => am.MovieId == id))
                .ToListAsync();
            if (result == null)
                throw new NotFoundException(nameof(Movie));
            List<ActorDTO> actors = new List<ActorDTO>();
            foreach(var actor in result)
            {
                actors.Add(new ActorDTO
                {
                    Id = actor.Id,
                    Name = actor.Name
                });
            }
            return actors;

        }
    }
}
