using FinalProject.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Database
{
    public class DbContextService : DbContext
    {
        public DbContextService( DbContextOptions<DbContextService> options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<PersonalInformation> PersonalInformations { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(i => i.PersonalInformation)
                .WithMany(i => i.Images)
                .HasForeignKey(p => p.PersonalInformationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.PersonalInformation)
                .WithOne(pi => pi.User)
                .HasForeignKey<PersonalInformation>(pi => pi.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonalInformation>()
                .HasOne(a => a.Address)
                .WithOne(p => p.PersonalInformation)
                .HasForeignKey<Address>(p => p.PersonalInformationId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
