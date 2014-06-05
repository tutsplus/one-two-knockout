using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        public string title { get; set; }
        public int openingGross { get; set; }
        public DateTime date { get; set; }
        public List<string> cast { get; set; }
    }
}