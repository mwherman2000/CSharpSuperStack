using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlazorApp4s.Data;
using BlazorApp4s.Models;

namespace BlazorApp4s.Pages.Operators
{
    public class CreateModel : PageModel
    {
        private readonly BlazorApp4s.Data.BlazorApp4sContext _context;

        public CreateModel(BlazorApp4s.Data.BlazorApp4sContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Operator Operator { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Operator.Add(Operator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
