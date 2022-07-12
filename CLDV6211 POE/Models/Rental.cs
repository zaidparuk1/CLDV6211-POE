using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CLDV6211_POE.Models
{
    [Table("Rental")]
    public partial class Rental
    {
        public Rental()
        {
            RentalReturns = new HashSet<RentalReturn>();
        }

        [Key]
        [Column("Rental_no")]
        [StringLength(6)]
        public string RentalNo { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal RentalFee { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(8)]
        public string CarNo { get; set; }
        [Required]
        [Column("Inspector_no")]
        [StringLength(6)]
        public string InspectorNo { get; set; }
        [Required]
        [Column("Driver_ID")]
        [StringLength(10)]
        public string DriverId { get; set; }

        [ForeignKey(nameof(CarNo))]
        [InverseProperty(nameof(Car.Rentals))]
        public virtual Car CarNoNavigation { get; set; }
        [ForeignKey(nameof(DriverId))]
        [InverseProperty("Rentals")]
        public virtual Driver Driver { get; set; }
        [ForeignKey(nameof(InspectorNo))]
        [InverseProperty(nameof(Inspector.Rentals))]
        public virtual Inspector InspectorNoNavigation { get; set; }
        [InverseProperty(nameof(RentalReturn.RentalNoNavigation))]
        public virtual ICollection<RentalReturn> RentalReturns { get; set; }
    }
}
