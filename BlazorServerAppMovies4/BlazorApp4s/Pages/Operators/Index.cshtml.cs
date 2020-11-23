using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorApp4s.Data;
using BlazorApp4s.Models;

namespace BlazorApp4s.Pages.Operators
{
    public class IndexModel : PageModel
    {
        private readonly BlazorApp4s.Data.BlazorApp4sContext _context;

        public IndexModel(BlazorApp4s.Data.BlazorApp4sContext context)
        {
            _context = context;
        }

        public IList<Operator> Operator { get;set; }

        public async Task OnGetAsync()
        {
            Operator = await _context.Operator.ToListAsync();
        }
    }
}
