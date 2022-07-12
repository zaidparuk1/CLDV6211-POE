using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CLDV6211_POE.Models
{
    [Table("RentalReturn")]
    public partial class RentalReturn
    {
        [Key]
        [Column("Return_No")]
        [StringLength(6)]
        public string ReturnNo { get; set; }
        [Required]
        [Column("Rental_no")]
        [StringLength(6)]
        public string RentalNo { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }
        public int ElapsedDate { get; set; }
        public int? Fine { get; set; }

        [ForeignKey(nameof(RentalNo))]
        [InverseProperty(nameof(Rental.RentalReturns))]
        public virtual Rental RentalNoNavigation { get; set; }
    }
}
