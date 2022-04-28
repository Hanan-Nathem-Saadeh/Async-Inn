﻿// <auto-generated />
using System;
using Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Async_Inn_Management_System.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20220427230403_UpdateRoomAmenitiesTable")]
    partial class UpdateRoomAmenitiesTable
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

            modelBuilder.Entity("Async_Inn_Management_System.Models.HotelRoom", b =>
                {
                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("RoomNumber", "HotelID");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRoom");
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

            modelBuilder.Entity("Async_Inn_Management_System.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("AmenityID")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenitiesId");

                    b.HasIndex("AmenityID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.HotelRoom", b =>
                {
                    b.HasOne("Async_Inn_Management_System.HotelModels.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Async_Inn_Management_System.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.RoomAmenities", b =>
                {
                    b.HasOne("Async_Inn_Management_System.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenity")
                        .HasForeignKey("AmenityID");

                    b.HasOne("Async_Inn_Management_System.Models.Room", "Room")
                        .WithMany("RoomAmenity")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Async_Inn_Management_System.HotelModels.Hotel", b =>
                {
                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenity");
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Room", b =>
                {
                    b.Navigation("HotelRoom");

                    b.Navigation("RoomAmenity");
                });
#pragma warning restore 612, 618
        }
    }
}
