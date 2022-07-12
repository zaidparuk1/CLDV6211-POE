using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CLDV6211_POE.Models
{
    [Table("Car")]
    public partial class Car
    {
        public Car()
        {
            Rentals = new HashSet<Rental>();
        }

        [Key]
        [StringLength(8)]
        public string CarNo { get; set; }
        [Required]
        [Column("Car_Make")]
        [StringLength(25)]
        public string CarMake { get; set; }
        [StringLength(30)]
        public string Model { get; set; }
        [StringLength(15)]
        public string BodyType { get; set; }
        [Column("Kilometres_Travelled")]
        public int? KilometresTravelled { get; set; }
        [Column("Service_kilometres")]
        public int? ServiceKilometres { get; set; }
        [Required]
        [StringLength(4)]
        public string Avaliable { get; set; }

        [InverseProperty(nameof(Rental.CarNoNavigation))]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
