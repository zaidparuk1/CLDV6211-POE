using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CLDV6211_POE.Data;
using CLDV6211_POE.Models;

namespace CLDV6211_POE.Pages.Returns
{
    public class DetailsModel : PageModel
    {
        private readonly CLDV6211_POE.Data.ApplicationDbContext _context;

        public DetailsModel(CLDV6211_POE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
