﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseStore.Database;

#nullable disable

namespace WarehouseStore.Migrations
{
    [DbContext(typeof(DbContextService))]
    partial class DbContextServiceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WarehouseStore.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("WarehouseStore.Models.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SKUId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("SKUId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("WarehouseStore.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SKUId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SKUId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("WarehouseStore.Models.SKU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SKUs");
                });

            modelBuilder.Entity("WarehouseStore.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("FreeSpace")
                        .HasColumnType("int");

                    b.Property<int>("GoodsReserved")
                        .HasColumnType("int");

                    b.Property<int>("GoodsStored")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("WarehouseStore.Models.WarehouseSKUInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlannedDeliveryQuantity")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ReservedQuantity")
                        .HasColumnType("int");

                    b.Property<int>("SKUId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SKUId");

                    b.ToTable("warehouseSKUInfos");
                });

            modelBuilder.Entity("WarehouseStore.Models.InvoiceItem", b =>
                {
                    b.HasOne("WarehouseStore.Models.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseStore.Models.SKU", "SKU")
                        .WithMany()
                        .HasForeignKey("SKUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseStore.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("SKU");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WarehouseStore.Models.Reservation", b =>
                {
                    b.HasOne("WarehouseStore.Models.SKU", "SKU")
                        .WithMany("Reservations")
                        .HasForeignKey("SKUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SKU");
                });

            modelBuilder.Entity("WarehouseStore.Models.WarehouseSKUInfo", b =>
                {
                    b.HasOne("WarehouseStore.Models.SKU", "SKU")
                        .WithMany("WarehousesSKUInfos")
                        .HasForeignKey("SKUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SKU");
                });

            modelBuilder.Entity("WarehouseStore.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("WarehouseStore.Models.SKU", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("WarehousesSKUInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
