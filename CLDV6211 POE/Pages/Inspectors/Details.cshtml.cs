﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CLDV6211_POE.Data;
using CLDV6211_POE.Models;

namespace CLDV6211_POE.Pages.Inspectors
{
    public class DetailsModel : PageModel
    {
        private readonly CLDV6211_POE.Data.ApplicationDbContext _context;

        public DetailsModel(CLDV6211_POE.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Inspector Inspector { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inspector = await _context.Inspector.FirstOrDefaultAsync(m => m.InspectorNo == id);

            if (Inspector == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
