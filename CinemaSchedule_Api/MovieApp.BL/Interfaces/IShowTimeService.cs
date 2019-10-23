using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.BL.Interfaces
{
    public interface IShowTimeService : IService<ShowTime>
    {
        Task<IEnumerable<string>> GetDates();
        Task<IEnumerable<string>> GetTimes(string date, int movie_id);
    }
}
