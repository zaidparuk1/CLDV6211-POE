using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CLDV6211_POE.Models
{
    public partial class ApplicationDbContext2 : DbContext
    {
        public ApplicationDbContext2()
        {
        }

        public ApplicationDbContext2(DbContextOptions<ApplicationDbContext2> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Inspector> Inspectors { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<RentalReturn> RentalReturns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-CLDV6211_POE-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarNo)
                    .HasName("PK__Car__68A00DDDD29F1B39");

                entity.Property(e => e.CarNo).IsUnicode(false);

                entity.Property(e => e.Avaliable).IsUnicode(false);

                entity.Property(e => e.BodyType).IsUnicode(false);

                entity.Property(e => e.CarMake).IsUnicode(false);

                entity.Property(e => e.Model).IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverId).IsUnicode(false);

                entity.Property(e => e.DriverAddress).IsUnicode(false);

                entity.Property(e => e.DriverEmail).IsUnicode(false);

                entity.Property(e => e.DriverName).IsUnicode(false);
            });

            modelBuilder.Entity<Inspector>(entity =>
            {
                entity.HasKey(e => e.InspectorNo)
                    .HasName("PK__Inspecto__F49FBEAF45138476");

                entity.Property(e => e.InspectorNo).IsUnicode(false);

                entity.Property(e => e.InspectorEmail).IsUnicode(false);

                entity.Property(e => e.InspectorMobile).IsUnicode(false);

                entity.Property(e => e.InspectorName).IsUnicode(false);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.RentalNo)
                    .HasName("PK__Rental__9D2089951A64559D");

                entity.Property(e => e.RentalNo).IsUnicode(false);

                entity.Property(e => e.CarNo).IsUnicode(false);

                entity.Property(e => e.DriverId).IsUnicode(false);

                entity.Property(e => e.InspectorNo).IsUnicode(false);

                entity.HasOne(d => d.CarNoNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CarNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rental__CarNo__5441852A");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rental__Driver_I__5629CD9C");

                entity.HasOne(d => d.InspectorNoNavigation)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.InspectorNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rental__Inspecto__5535A963");
            });

            modelBuilder.Entity<RentalReturn>(entity =>
            {
                entity.HasKey(e => e.ReturnNo)
                    .HasName("PK__RentalRe__0F4F6B99C90FA692");

                entity.Property(e => e.ReturnNo).IsUnicode(false);

                entity.Property(e => e.RentalNo).IsUnicode(false);

                entity.HasOne(d => d.RentalNoNavigation)
                    .WithMany(p => p.RentalReturns)
                    .HasForeignKey(d => d.RentalNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RentalRet__Renta__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
