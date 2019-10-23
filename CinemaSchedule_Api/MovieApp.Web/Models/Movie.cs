using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Web.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
    }
}
