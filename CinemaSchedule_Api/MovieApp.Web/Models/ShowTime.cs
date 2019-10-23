using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Web.Models
{
    public class ShowTimeModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int MovieId { get; set; }
    }
}