using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Text;

namespace Movies.Controllers
{
    public class ApiController : Controller
    {

        public JsonResult Index()
        {
            var _db = new MovieDb(Server.MapPath("movie.json"));
            var movies = _db.SelectAllMovies();
            return Json(movies, JsonRequestBehavior.AllowGet);
        }


    }
}
