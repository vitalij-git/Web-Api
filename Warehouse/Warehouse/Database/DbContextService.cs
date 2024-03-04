using Microsoft.EntityFrameworkCore;
using System.Net;
using WarehouseStore.Models;

namespace WarehouseStore.Database
{
    public class DbContextService : DbContext
    {
        public DbContextService(DbContextOptions<DbContextService> options) : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SKU> SKUs { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseSKUInfo> warehouseSKUInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceItems)
                .WithOne(i => i.Invoice)
                .HasForeignKey(i => i.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SKU>()
               .HasMany(sk => sk.Reservations)
               .WithOne(sk => sk.SKU)
               .HasForeignKey(sk => sk.SKUId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SKU>()
               .HasMany(sk => sk.WarehousesSKUInfos)
               .WithOne(sk => sk.SKU)
               .HasForeignKey(sk => sk.SKUId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
