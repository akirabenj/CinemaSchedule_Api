using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.BL.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}
