using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazorApp4s.Data;
using BlazorApp4s.Models;

namespace BlazorApp4s.Pages.Operators
{
    public class EditModel : PageModel
    {
        private readonly BlazorApp4s.Data.BlazorApp4sContext _context;

        public EditModel(BlazorApp4s.Data.BlazorApp4sContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Operator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperatorExists(Operator.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OperatorExists(int id)
        {
            return _context.Operator.Any(e => e.Id == id);
        }
    }
}
