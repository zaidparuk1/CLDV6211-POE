using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CLDV6211_POE.Models
{
    [Table("Inspector")]
    public partial class Inspector
    {
        public Inspector()
        {
            Rentals = new HashSet<Rental>();
        }

        [Key]
        [Column("Inspector_no")]
        [StringLength(6)]
        public string InspectorNo { get; set; }
        [Required]
        [StringLength(50)]
        public string InspectorName { get; set; }
        [Required]
        [StringLength(50)]
        public string InspectorEmail { get; set; }
        [StringLength(20)]
        public string InspectorMobile { get; set; }

        [InverseProperty(nameof(Rental.InspectorNoNavigation))]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
