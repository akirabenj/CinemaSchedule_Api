using MovieApp.BL.DTO;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.BL.Interfaces
{
    public interface IMovieService : IService<MovieDTO>
    {
        Task<IEnumerable<MovieDTO>> GetMoviesByDateAsync(string date);
        Task<IEnumerable<MovieDTO>> GetAll();
    }
}
