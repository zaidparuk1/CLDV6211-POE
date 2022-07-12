using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDV6211_POE.Data;
using CLDV6211_POE.Models;

namespace CLDV6211_POE.Pages.Returns
{
    public class EditModel : PageModel
    {
        private readonly CLDV6211_POE.Data.ApplicationDbContext _context;

        public EditModel(CLDV6211_POE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RentalReturn RentalReturn { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RentalReturn = await _context.RentalReturn
                .Include(r => r.RentalNoNavigation).FirstOrDefaultAsync(m => m.ReturnNo == id);

            if (RentalReturn == null)
            {
                return NotFound();
            }
           ViewData["RentalNo"] = new SelectList(_context.Rental, "RentalNo", "RentalNo");
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

            _context.Attach(RentalReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalReturnExists(RentalReturn.ReturnNo))
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

        private bool RentalReturnExists(string id)
        {
            return _context.RentalReturn.Any(e => e.ReturnNo == id);
        }
    }
}
