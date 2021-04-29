using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Klasy;

namespace WebApplication.Pages.Kierowca
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Data.WebApplicationContext _context;

        public DeleteModel(WebApplication.Data.WebApplicationContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kierowca = await _context.Kierowca.FindAsync(id);

            if (Kierowca != null)
            {
                _context.Kierowca.Remove(Kierowca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
