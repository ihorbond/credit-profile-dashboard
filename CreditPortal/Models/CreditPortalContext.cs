using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CreditPortal.Models
{
    public partial class CreditPortalContext : DbContext
    {
        public CreditPortalContext()
        {
        }

        public CreditPortalContext(DbContextOptions<CreditPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditProfile> CreditProfile { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CreditProfile>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime2(1)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LineOfCredit).HasColumnType("money");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime2(1)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CreditProfile)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditProfile_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime2(1)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime2(1)");
            });
        }
    }
}
