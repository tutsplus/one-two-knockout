using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Text;

namespace Movies.Models
{
    public class MovieDb
    {

        public string FilePath { get; set; }

        public MovieDb(string filePath)
        {
            FilePath = filePath;
        }

        public IEnumerable<Movie> SelectAllMovies()
        {
            var movies = ReadFromFile();
            return movies;
        }

        private IEnumerable<Movie> ReadFromFile()
        {
            var map = new string[4] { "title", "openingGross", "date", "cast" };
            List<Movie> movies = new List<Movie>();
            var json = System.IO.File.ReadAllText(FilePath);

            var objects = JArray.Parse(json);
            
            foreach (JObject root in objects)
            {
                var title = (String)root[MovieMap.title.ToString()];
                var gross = (Int32)root[MovieMap.openingGross.ToString()];
                var date = (DateTime)root[MovieMap.date.ToString()];
                var cast = new List<string>();
                if (root["cast"] != null)
                {
                    var castArr = root["cast"].ToArray() ?? null;
                    
                    foreach (var item in castArr)
                    {
                        cast.Add((string)item);
                    }   
                }
                var movie = new Movie()
                {
                    title = title,
                    openingGross = gross,
                    date = date,
                    cast = cast
                };
                movies.Add(movie);
            }
            
            return movies;
        }



        public enum MovieMap
        {
            title,
            openingGross,
            date,
            cast
        }

    }
}