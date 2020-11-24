using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Parallelspace.CSharpSuperStack
{
    public class Neo4jEntities
    {
        public static List<INode> Query()
        {
            return Query("", null);
        }

        public static List<INode> Query(string filterlabel)
        {
            return Query(filterlabel, null);
        }

        public static List<INode> Query(string filterlabel, Dictionary<string, object> filterprops)
        {
            string cmd;
            IResult result = null;
            List<INode> values;
            StringBuilder fitercmd = new StringBuilder();
            string matchcmd = "MATCH ( s{0} {1} ) "; // s:Movie {a:1234 b:"abcd"}
            string retcmd = "RETURN s";

            if (filterprops == null) filterprops = new Dictionary<string, object>();

            fitercmd.Append("");
            if (filterprops.Keys.Count > 0)
            {
                fitercmd.Append("{ ");
                foreach (var prop in filterprops)
                {
                    if (Neo4jHelpers.IsNumeric(prop.Value.ToString()))
                    {
                        fitercmd.Append(prop.Key + ":" + prop.Value + " ");
                    }
                    else
                    {
                        fitercmd.Append(prop.Key + ":\"" + prop.Value + "\" ");
                    }
                }
                fitercmd.Append("}");
            }

            if (String.IsNullOrEmpty(filterlabel))
            {
                cmd = String.Format(matchcmd, "", fitercmd.ToString()) + retcmd;
            }
            else
            {
                cmd = String.Format(matchcmd, ":" + filterlabel, fitercmd.ToString()) + retcmd;
            }

            Debug.WriteLine("Query: '" + cmd + "'");

            using (var session = Neo4jHelpers.GetSession())
            {
                values = session.WriteTransaction(tx => {
                    result = tx.Run(cmd);
                    return result.Select(record => record[0].As<INode>()).ToList();
                }
                );
            }

            return values;
        }

        public static List<INode> Query(long id)
        {
            string cmd;
            IResult result = null;
            List<INode> values;
            StringBuilder fitercmd = new StringBuilder();
            string matchcmd = "MATCH ( s ) WHERE id(s)={0} "; 
            string retcmd = "RETURN s";

            cmd = String.Format(matchcmd, id) + retcmd;

            Debug.WriteLine("Query: '" + cmd + "'");

            using (var session = Neo4jHelpers.GetSession())
            {
                values = session.WriteTransaction(tx => {
                    result = tx.Run(cmd);
                    return result.Select(record => record[0].As<INode>()).ToList();
                }
                );
            }

            return values;
        }

        public static List<INode> Create(string label, Dictionary<string, object> properties)
        {
            string cmd;
            IResult result = null;
            List<INode> values;
            StringBuilder propscmd = new StringBuilder();
            string createcmd = "CREATE ( s{0} {1} ) "; // s:Movie {a:1234 b:"abcd"}
            string retcmd = "RETURN s";

            if (String.IsNullOrEmpty(label)) throw new ArgumentNullException();
            if (properties == null) throw new ArgumentNullException();
            if (properties.Count < 1) throw new ArgumentOutOfRangeException();
            if (properties.Keys.Contains("id")) throw new ArgumentOutOfRangeException();

            propscmd.Append("{ ");
            int pindex = 0;
            foreach (var prop in properties)
            {
                if (Neo4jHelpers.IsNumeric(prop.Value.ToString()))
                {
                    propscmd.Append(prop.Key + ":" + prop.Value + "");
                }
                else
                {
                    propscmd.Append(prop.Key + ":\"" + prop.Value + "\"");
                }
                pindex++;
                if (pindex < properties.Count) propscmd.Append(", ");
            }
            propscmd.Append("} ");

            cmd = String.Format(createcmd, ":" + label, propscmd.ToString()) + retcmd;

            Debug.WriteLine("Create: '" + cmd + "'");

            using (var session = Neo4jHelpers.GetSession())
            {
                values = session.WriteTransaction(tx => {
                    result = tx.Run(cmd);
                    return result.Select(record => record[0].As<INode>()).ToList();
                }
                );
            }

            return values;
        }

        public static List<INode> Update(string label, Dictionary<string, object> properties)
        {
            string cmd;
            IResult result = null;
            List<INode> values;
            StringBuilder cmdsb = new StringBuilder();
            string matchcmd = "MATCH ( s:{0} ) WHERE id(s)={1} SET ";
            string setcomma = " s.{0} = ${0}, ";
            string set = " s.{0} = ${0} ";
            string ret = " RETURN s";

            if (!properties.Keys.Contains("id")) throw new ArgumentOutOfRangeException();

            string id = properties["id"].ToString();

            cmdsb.Append(String.Format(matchcmd, label, id));

            if (properties.Keys.Count > 1)
            {
                int kindex = 0;
                foreach (string key in properties.Keys)
                {
                    if (key.ToLower() != "id")
                    {
                        if (kindex < properties.Keys.Count - 1)
                        {
                            cmdsb.AppendFormat(setcomma, key);
                        }
                        else
                        {
                            cmdsb.AppendFormat(set, key);
                        }
                    }
                    kindex++;
                }
            }

            cmdsb.Append(ret);
            cmd = cmdsb.ToString();

            Debug.WriteLine("Update: '" + cmd + "'");

            using (var session = Neo4jHelpers.GetSession())
            {
                values = session.WriteTransaction(tx => {
                    result = tx.Run(cmd, properties);
                    return result.Select(record => record[0].As<INode>()).ToList();
                }
                );
            }

            return values;
        }

        //public static void Replace(string filterlabel, Dictionary<string, object> filterprops, Dictionary<string, object> newprops)
        //{

        //}

        //public static void Update(string filterlabel, Dictionary<string, object> filterprops, Dictionary<string, object> newprops)
        //{

        //}

        public static string Delete(string id)
        {
            string deletecmd = "MATCH (s) WHERE id(s)={0} DELETE s RETURN COUNT(s) ";
            IResult result = null;
            string value;

            if (String.IsNullOrEmpty(id)) throw new ArgumentNullException();
            if (!Neo4jHelpers.IsNumeric(id)) throw new ArgumentOutOfRangeException();

            string cmd = String.Format(deletecmd, id);

            using (var session = Neo4jHelpers.GetSession())
            {
                value = session.WriteTransaction(tx => { result = tx.Run(cmd); return result.Single()[0].As<string>(); });
            }

            return value;
        }

        public static string DeleteWithLabel(string filterlabel)
        {
            string deletecmd = "MATCH (s:{0}) DELETE s RETURN COUNT(s) ";
            IResult result = null;
            string value;

            string cmd = String.Format(deletecmd, filterlabel);

            using (var session = Neo4jHelpers.GetSession())
            {
                value = session.WriteTransaction(tx => { result = tx.Run(cmd); return result.Single()[0].As<string>(); });
            }

            return value;
        }
    }
}
