using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CLDV6211_POE.Data;
using CLDV6211_POE.Models;

namespace CLDV6211_POE.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CLDV6211_POE.Data.ApplicationDbContext _context;

        public DetailsModel(CLDV6211_POE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.CarNo == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
