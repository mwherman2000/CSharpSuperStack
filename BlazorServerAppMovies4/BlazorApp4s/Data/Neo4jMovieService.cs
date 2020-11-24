using BlazorApp4s.Models;
using Neo4j.Driver;
using Parallelspace.CSharpSuperStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4s.Data
{
    public class Neo4jMovieService
    {
        public INode[] GetMovies()
        {
            List<INode> entities = Neo4jEntities.Query("Movie");

            return entities.ToArray<INode>();
        }

        public Task<INode[]> GetMoviesAsync()
        {
            return Task.Run( () =>
            {
                INode[] entities = Neo4jEntities.Query("Movie").ToArray<INode>();
                return entities;
            });
        }

        public Task MergeMovieAsync(Movie movie)
        {
            return Task.Run(() =>
            {
                if (String.IsNullOrEmpty(movie.Id))
                {
                    INode[] entities = Neo4jEntities.Create("Movie", new Dictionary<string, object>()
                {
                    { "title", movie.Title },
                    { "released", movie.Released },
                    { "tagline", movie.Tagline }
                }).ToArray<INode>();
                    return entities;
                }
                else
                {
                    INode[] entities = Neo4jEntities.Update("Movie", new Dictionary<string, object>()
                {
                    { "id", movie.Id },
                    { "title", movie.Title },
                    { "released", movie.Released },
                    { "tagline", movie.Tagline }
                }).ToArray<INode>();
                    return entities;
                }
            });
        }

        public Task DeleteMovieAsync(Movie movie)
        {
            return Task.Run(() =>
            {
                string result = Neo4jEntities.Delete(movie.Id);
                return result;
            });
        }
    }
}
