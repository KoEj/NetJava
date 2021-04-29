using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Klasy;

namespace WebApplication.Pages.Kierowca
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Data.WebApplicationContext _context;

        public EditModel(WebApplication.Data.WebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kierowca Kierowca { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kierowca = await _context.Kierowca.FirstOrDefaultAsync(m => m.ID == id);

            if (Kierowca == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kierowca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KierowcaExists(Kierowca.ID))
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

        private bool KierowcaExists(string id)
        {
            return _context.Kierowca.Any(e => e.ID == id);
        }
    }
}
