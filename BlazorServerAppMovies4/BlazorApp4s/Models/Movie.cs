using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4s.Models
{
    public class Movie
    {
        public string Id;
        public string Title;
        public string Released;
        public string Tagline;

        public Movie( string id, string title, string released, string tagline)
        {
            Id = id;
            Title = title;
            Released = released;
            Tagline = tagline;
        }

        public Movie(Neo4j.Driver.INode movie)
        {
            Id = movie.Id.ToString();
            Title = movie.Properties["title"].ToString();
            Released = movie.Properties["released"].ToString();
            Tagline = movie.Properties["tagline"].ToString();
        }
    }
}
