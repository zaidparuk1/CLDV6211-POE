using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CLDV6211_POE.Data;
using CLDV6211_POE.Models;

namespace CLDV6211_POE.Pages.Rentals
{
    public class IndexModel : PageModel
    {
        private readonly CLDV6211_POE.Data.ApplicationDbContext _context;

        public IndexModel(CLDV6211_POE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Rental> Rental { get;set; }

        public async Task OnGetAsync()
        {
            Rental = await _context.Rental
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .Include(r => r.InspectorNoNavigation).ToListAsync();
        }
    }
}
