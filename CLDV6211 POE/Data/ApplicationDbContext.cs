using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CLDV6211_POE.Models;

namespace CLDV6211_POE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CLDV6211_POE.Models.Car> Car { get; set; }
        public DbSet<CLDV6211_POE.Models.Driver> Driver { get; set; }
        public DbSet<CLDV6211_POE.Models.Inspector> Inspector { get; set; }
        public DbSet<CLDV6211_POE.Models.Rental> Rental { get; set; }
        public DbSet<CLDV6211_POE.Models.RentalReturn> RentalReturn { get; set; }
    }
}
