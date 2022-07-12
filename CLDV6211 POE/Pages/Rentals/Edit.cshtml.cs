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

namespace CLDV6211_POE.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly CLDV6211_POE.Data.ApplicationDbContext _context;

        public EditModel(CLDV6211_POE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rental = await _context.Rental
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .Include(r => r.InspectorNoNavigation).FirstOrDefaultAsync(m => m.RentalNo == id);

            if (Rental == null)
            {
                return NotFound();
            }
           ViewData["CarNo"] = new SelectList(_context.Car, "CarNo", "CarNo");
           ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId");
           ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo");
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

            _context.Attach(Rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(Rental.RentalNo))
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

        private bool RentalExists(string id)
        {
            return _context.Rental.Any(e => e.RentalNo == id);
        }
    }
}
