using Microsoft.EntityFrameworkCore;
using MovieApp.BL.Interfaces;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.BL.Services
{
    public class ShowTimeService : IShowTimeService
    {
        private readonly MovieAppContext Context;

        public ShowTimeService(MovieAppContext context)
        {
            Context = context;
        }

        public async Task<ShowTime> GetById(int id)
        {
            return await Context.ShowTimes.FindAsync(id);
        }

        public async Task<IEnumerable<string>> GetDates()
        {
            return await Context.ShowTimes
                .Select(d => d.Date)
                .Distinct()
                .ToListAsync();
                
        }

        public async Task<IEnumerable<string>> GetTimes(string date, int movie_id)
        {
            return await Context.ShowTimes
                .Where(st => st.Date == date && st.MovieId == movie_id)
                .Select(t => t.Time)
                .ToListAsync();
        }
    }
}

