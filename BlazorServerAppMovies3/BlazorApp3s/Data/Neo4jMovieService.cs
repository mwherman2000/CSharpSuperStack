using Neo4j.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp3s.Data
{
    public class Neo4jMovieService
    {

        public Task<INode[]> GetMoviesAsync()
        {
            IDriver driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "Movies"));

            using (var session = driver.Session())
            {
                return Task.FromResult(
                    session.ReadTransaction(tx =>
                    {
                        var result = tx.Run("MATCH (movie:Movie) RETURN movie ORDER BY movie.released");
                        return result.Select(record => record[0].As<INode>()).ToArray();
                    })
                );
            }
        }
    }
}
