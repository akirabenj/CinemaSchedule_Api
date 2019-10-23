using Microsoft.EntityFrameworkCore;
using MovieApp.BL.Interfaces;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieAppContext Context;

        public MovieService(MovieAppContext context) 
        { 
            Context = context;
        }

        public async Task<Movie> GetById(int id)
        { 
            return await Context.Movies
                .Include(m => m.Genre)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByDate(string date)
        {
            var movieIds = Context.ShowTimes
                .Where(s => s.Date == date)
                .Select(m => m.MovieId)
                .Distinct()
                .ToArray();
            if (movieIds.Length == 0)
                return null;

            return await Context.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToListAsync();
        }

    }
}