using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Entities
{
    public class ShowTime : BaseEntity
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}