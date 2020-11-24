using Neo4j.Driver;
using System;
using System.Collections.Generic;

namespace Parallelspace.CSharpSuperStack.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All");
            List<INode> entities = Neo4jEntities.Query();
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
            }

            Console.WriteLine("Movie");
            entities = Neo4jEntities.Query("Movie");
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
            }

            Console.WriteLine("{ \"title\", \"Top Gun\" }");
            entities = Neo4jEntities.Query("Movie", new Dictionary<string, object>()
            {
                { "title", "Top Gun" }
            });
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
            }

            Console.WriteLine("{ \"released\", 1999 }");
            entities = Neo4jEntities.Query("Movie", new Dictionary<string, object>()
            {
                { "released", 1999 }
            });
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
            }

            Console.WriteLine("{ \"released\", 1999 }");
            entities = Neo4jEntities.Query("Movie", new Dictionary<string, object>()
            {
                { "released", 1999 }
            });
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
            }

            Console.WriteLine("id(s)=29");
            entities = Neo4jEntities.Query(29);
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
            }

            string count = "";
            //Console.WriteLine("Delete(\"foobar\")");
            //count = Neo4jEntities.DeleteWithLabel("foobar");
            //Console.WriteLine("Count: " + count);

            string lastid = "";
            Console.WriteLine("Create(\"foobar\")");
            entities = Neo4jEntities.Create("foobar", new Dictionary<string, object>()
            {
                { "title", "Hi there" },
                { "released", 2020 },
                { "tagline", "Hello world" }
            });
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
                lastid = e.Id.ToString();
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            Console.WriteLine("Update(\"foobar\")");
            entities = Neo4jEntities.Update("foobar", new Dictionary<string, object>()
            {
                { "id", 171 },
                { "title", "Hi there 2" },
                { "released", 2024 },
                { "tagline", "Hello world 2" }
            });
            foreach (var e in entities)
            {
                Console.WriteLine(e.Id);
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            Console.WriteLine("Delete(lastid)");
            count = Neo4jEntities.Delete(lastid);
            Console.WriteLine("Count: " + count);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            Console.WriteLine("Delete(\"foobar\")");
            count = Neo4jEntities.DeleteWithLabel("foobar");
            Console.WriteLine("Count: " + count);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
