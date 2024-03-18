using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BackEnd.Database
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options) 
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
        public DbSet<Window> Windows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubElement>()
                .HasOne(sub => sub.Window)
                .WithMany(sub => sub.SubElements)
                .HasForeignKey(sub => sub.WindowId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Window>()
                .HasOne(win => win.Order)
                .WithMany(win => win.Windows)
                .HasForeignKey(win => win.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
