using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4s.Models
{
    public class Pasture
    {
        public Pasture()
        {
            Fields = new List<Field>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Field> Fields { get; set; }
    }
}
