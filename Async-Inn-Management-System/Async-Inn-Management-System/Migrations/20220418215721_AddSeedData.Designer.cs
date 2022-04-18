﻿// <auto-generated />
using Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Async_Inn_Management_System.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20220418215721_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Async_Inn_Management_System.HotelModels.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hotel_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel_Street_Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Hotel_City = "Amman",
                            Hotel_Country = "Jordan",
                            Hotel_Name = "Hanan Hotel",
                            Hotel_Phone = "0781234567",
                            Hotel_State = "Amman",
                            Hotel_Street_Address = "One Street"
                        },
                        new
                        {
                            ID = 2,
                            Hotel_City = "Ajloun",
                            Hotel_Country = "Jordan",
                            Hotel_Name = "Lojain Hotel",
                            Hotel_Phone = "0794312333",
                            Hotel_State = "Ajloun",
                            Hotel_Street_Address = "Two Street"
                        },
                        new
                        {
                            ID = 3,
                            Hotel_City = "Jarash",
                            Hotel_Country = "Jordan",
                            Hotel_Name = "Mohammad Hotel",
                            Hotel_Phone = "0778900000",
                            Hotel_State = "Jarash",
                            Hotel_Street_Address = "Three Street"
                        });
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amenity_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Amenity_Name = "Mini bar"
                        },
                        new
                        {
                            ID = 2,
                            Amenity_Name = "ocean view"
                        },
                        new
                        {
                            ID = 3,
                            Amenity_Name = "coffee maker"
                        });
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Room_Layout")
                        .HasColumnType("int");

                    b.Property<string>("Room_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Room_Layout = 2,
                            Room_Name = "Seahawks Snooze"
                        },
                        new
                        {
                            ID = 2,
                            Room_Layout = 1,
                            Room_Name = "Restful Rainier"
                        },
                        new
                        {
                            ID = 3,
                            Room_Layout = 0,
                            Room_Name = "classic Snooze"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
