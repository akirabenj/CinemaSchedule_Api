using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.BL.Interfaces
{
    public interface IActorService : IService<Actor>
    {
        Task<IEnumerable<Actor>> GetMovieActors(int id);
    }
}
