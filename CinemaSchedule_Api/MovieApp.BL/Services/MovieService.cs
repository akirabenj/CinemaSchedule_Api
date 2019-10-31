using Microsoft.EntityFrameworkCore;
using MovieApp.BL.Infrastructure;
using MovieApp.BL.Interfaces;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.BL.DTO;

namespace MovieApp.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieAppContext Context;

        public MovieService(MovieAppContext context) 
        { 
            Context = context;
        }

        public async Task<MovieDTO> GetByIdAsync(int id)
        { 
            var result = await Context.Movies.Include(m => m.Genre).SingleOrDefaultAsync(m => m.Id == id);
            if (result == null)
                throw new NotFoundException(nameof(Movie));

            var movie = new MovieDTO
            {
                Id = result.Id,
                Name = result.Name,
                Image = result.ImageUri,
                Description = result.Description,
                Genre = result.Genre.Name
            };

            return movie;
        }

        public async Task<IEnumerable<MovieDTO>> GetAll()
        {
            var result = await Context.Movies.Include(m=>m.Genre).ToListAsync();
            if (result == null)
                throw new NotFoundException(nameof(Movie));
            List<MovieDTO> movies = new List<MovieDTO>();

            foreach(var movie in result)
            {
                movies.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Image = movie.ImageUri,
                    Description = movie.Description,
                    Genre = movie.Genre.Name
                });
            }
            return movies;
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByDateAsync(string date)
        {
            var movieIds = Context.ShowTimes
                            .Where(s => s.Date == date)
                            .Select(m => m.MovieId)
                            .Distinct()
                            .ToArray();

            if (movieIds.Length == 0)
                throw new NotFoundException(nameof(Movie));

            var result = await Context.Movies
                                .Include(m=>m.Genre)
                                .Where(m => movieIds.Contains(m.Id))
                                .ToListAsync();

            List<MovieDTO> movies = new List<MovieDTO>();
            foreach (var movie in result)
            {
                movies.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Image = movie.ImageUri,
                    Description = movie.Description,
                    Genre = movie.Genre.Name
                });
            }

            return movies;
        }

    }
}