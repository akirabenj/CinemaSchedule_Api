using Microsoft.EntityFrameworkCore;
using MovieApp.BL.Infrastructure;
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

        public async Task<ShowTime> GetByIdAsync(int id)
        {
            var result = await Context.ShowTimes.FindAsync(id);
            if (result == null)
                throw new NotFoundException(nameof(ShowTime));

            return result; 
        }

        public async Task<IEnumerable<string>> GetDatesAsync()
        {
            var result = await Context.ShowTimes
                .Select(d => d.Date)
                .Distinct()
                .ToListAsync();
            if (result == null)
                throw new NotFoundException("Dates");
            
            return result;
        }

        public async Task<IEnumerable<string>> GetTimesAsync(string date, int movie_id)
        {
            var result = await Context.ShowTimes
                .Where(st => st.Date == date && st.MovieId == movie_id)
                .Select(t => t.Time)
                .ToListAsync();
            if (result == null)
                throw new NotFoundException("Times");

            return result;
        }
    }
}

