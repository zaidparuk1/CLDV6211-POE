using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CLDV6211_POE.Data;
using CLDV6211_POE.Models;

namespace CLDV6211_POE.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly CLDV6211_POE.Data.ApplicationDbContext _context;

        public CreateModel(CLDV6211_POE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarNo"] = new SelectList(_context.Car, "CarNo", "CarNo");
        ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "DriverId");
        ViewData["InspectorNo"] = new SelectList(_context.Inspector, "InspectorNo", "InspectorNo");
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rental.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
