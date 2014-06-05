using Movies.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/

        public string Index(string json)
        {
            var serializer = new JsonSerializer<Movie>();
            var movie = serializer.DeserializeFromString(json);
            return "Saved";
        }

    }
}
