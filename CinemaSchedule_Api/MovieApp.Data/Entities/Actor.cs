using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entities
{
    public class Actor : BaseEntity
    {
        public Actor()
        {
            ActorMovies = new HashSet<ActorMovies>();
        }

        public string Name { get; set; }
        public IEnumerable<ActorMovies> ActorMovies { get; set; }
    }
}
