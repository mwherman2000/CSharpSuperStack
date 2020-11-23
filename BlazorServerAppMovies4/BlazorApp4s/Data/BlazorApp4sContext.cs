using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp4s.Models;

namespace BlazorApp4s.Data
{
    public class BlazorApp4sContext : DbContext
    {
        public BlazorApp4sContext (DbContextOptions<BlazorApp4sContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp4s.Models.Operator> Operator { get; set; }
    }
}
