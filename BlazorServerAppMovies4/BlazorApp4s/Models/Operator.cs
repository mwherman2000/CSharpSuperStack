using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4s.Models
{
    public class Operator
    {
        public Operator()
        {
            Pastures = new List<Pasture>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pasture> Pastures { get; set; }
    }
}
