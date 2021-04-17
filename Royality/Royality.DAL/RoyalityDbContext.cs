using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Royality.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Royality.DAL
{
    public class RoyalityDbContext : DbContext
    {
        public RoyalityDbContext(DbContextOptions<RoyalityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Watch>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Watch>().HasData(new Watch

                    {
                        Id = 1,
                        ModelName = "Rolex 123",
                        Price = 25000.0M,
                        Size = 6.5,
                        GuaranteePeriod = 1.5,
                        Location = "Mirabad, Tashkent",
                        ManufacturerId = 1


                    }

                );

            modelBuilder.Entity<Manufacturer>().HasData(
                    new Manufacturer
                    {
                        Id = 1,
                        Name = "Rolex"
                    }

                );
        }

    
        public virtual DbSet<Watch> Watches { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
