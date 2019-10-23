using Microsoft.EntityFrameworkCore;
using MovieApp.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.BL.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
    }
}