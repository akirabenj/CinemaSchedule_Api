using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.BL.Interfaces
{
    public interface IMovieService : IService<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByDate(string date);
    }
}
