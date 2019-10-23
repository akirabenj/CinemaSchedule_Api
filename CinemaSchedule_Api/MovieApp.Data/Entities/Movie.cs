using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entities
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            ActorMovies = new HashSet<ActorMovies>();
        }

        public string Name { get; set; }
        public string ImageUri { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public IEnumerable<ActorMovies> ActorMovies {get;set;}   
    }
}
