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
    public class DetailsModel : PageModel
    {
        private readonly BlazorApp4s.Data.BlazorApp4sContext _context;

        public DetailsModel(BlazorApp4s.Data.BlazorApp4sContext context)
        {
            _context = context;
        }

        public Operator Operator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Operator = await _context.Operator.FirstOrDefaultAsync(m => m.Id == id);

            if (Operator == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
