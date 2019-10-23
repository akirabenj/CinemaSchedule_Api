using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entities
{
    public class ActorMovies : BaseEntity
    {
        public int ActorId { get; set; }
        public Actor Actors { get; set; }

        public int MovieId { get; set; }
        public Movie Movies { get; set; }
    }
}
