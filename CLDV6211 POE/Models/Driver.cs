using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CLDV6211_POE.Models
{
    [Table("Driver")]
    public partial class Driver
    {
        public Driver()
        {
            Rentals = new HashSet<Rental>();
        }

        [Key]
        [Column("Driver_ID")]
        [StringLength(10)]
        public string DriverId { get; set; }
        [Required]
        [StringLength(50)]
        public string DriverName { get; set; }
        [Required]
        [StringLength(100)]
        public string DriverAddress { get; set; }
        [Required]
        [StringLength(50)]
        public string DriverEmail { get; set; }
        public int? DriverMobile { get; set; }

        [InverseProperty(nameof(Rental.Driver))]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
