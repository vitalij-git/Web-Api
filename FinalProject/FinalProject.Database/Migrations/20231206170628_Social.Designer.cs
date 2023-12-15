﻿// <auto-generated />
using System;
using FinalProject.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Database.Migrations
{
    [DbContext(typeof(DbContextService))]
    [Migration("20231206170628_Social")]
    partial class Social
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<int>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PersonalInformationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInformationId")
                        .IsUnique()
                        .HasFilter("[PersonalInformationId] IS NOT NULL");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("PersonalInformationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInformationId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.PersonalInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PersonalCode")
                        .HasColumnType("bigint");

                    b.Property<long>("TelNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PersonalInformations");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("PersonalInformationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.Address", b =>
                {
                    b.HasOne("FinalProject.BusinessLogic.Models.PersonalInformation", "PersonalInformation")
                        .WithOne("Address")
                        .HasForeignKey("FinalProject.BusinessLogic.Models.Address", "PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.Image", b =>
                {
                    b.HasOne("FinalProject.BusinessLogic.Models.PersonalInformation", "PersonalInformation")
                        .WithMany("Images")
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.PersonalInformation", b =>
                {
                    b.HasOne("FinalProject.BusinessLogic.Models.User", "User")
                        .WithOne("PersonalInformation")
                        .HasForeignKey("FinalProject.BusinessLogic.Models.PersonalInformation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.PersonalInformation", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("FinalProject.BusinessLogic.Models.User", b =>
                {
                    b.Navigation("PersonalInformation");
                });
#pragma warning restore 612, 618
        }
    }
}