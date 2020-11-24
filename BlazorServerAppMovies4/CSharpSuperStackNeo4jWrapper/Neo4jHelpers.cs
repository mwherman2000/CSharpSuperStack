using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://neo4j.com/docs/driver-manual/current/get-started/

namespace Parallelspace.CSharpSuperStack
{
    public class Neo4jHelpers
    {
        static IDriver driver = null;
        static string driverurl = "bolt://localhost:7687";
        static IAuthToken authToken = AuthTokens.Basic("neo4j", "Movies");

        public static void CheckDriver()
        {
            if (driver == null) driver = GraphDatabase.Driver(driverurl, authToken);
        }

        public static ISession GetSession()
        {
            CheckDriver();
            var session = driver.Session();
            return session;
        }

        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
    }
}
