using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neo4jMovies1
{
    class Program
    {
        static IDriver driver;

        static void Main(string[] args)
        {
            driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "Movies"));

            List<INode> list = GetRecords();

            Console.WriteLine("Count:" + list.Count.ToString());

            foreach (INode n in list)
            {
                Console.WriteLine(n.Id.ToString());
            }

            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }

        static List<INode> GetRecords()
        {
            using (var session = driver.Session())
            {
                return session.ReadTransaction(tx =>
                {
                    var result = tx.Run("MATCH (movie:Movie) RETURN movie ORDER BY movie.title");
                    return result.Select(record => record[0].As<INode>()).ToList();
                });
            }
        }
    }
}

