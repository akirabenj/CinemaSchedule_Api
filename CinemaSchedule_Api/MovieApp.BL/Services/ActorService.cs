using Microsoft.EntityFrameworkCore;
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

        public async Task<Actor> GetById(int id)
        {
            return await Context.Actors.FindAsync(id);
        }

        public async Task<IEnumerable<Actor>> GetMovieActors(int id)
        {
            return await Context.Actors.Where(a => a.ActorMovies.Any(am => am.MovieId == id)).ToListAsync();
        }
    }
}
