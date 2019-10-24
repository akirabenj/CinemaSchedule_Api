using Microsoft.EntityFrameworkCore;
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

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await Context.Actors.FindAsync(id);
            if (result == null)
                throw new NotFoundException(nameof(Actor));

            return result;
        }

        public async Task<IEnumerable<Actor>> GetMovieActorsAsync(int id)
        {
            var result = await Context.Actors
                .Where(a => a.ActorMovies.Any(am => am.MovieId == id))
                .ToListAsync();
            if (result == null)
                throw new NotFoundException(nameof(Movie));

            return result;

        }
    }
}
