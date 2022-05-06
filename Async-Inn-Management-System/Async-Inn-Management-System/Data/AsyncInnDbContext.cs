using Async_Inn_Management_System.HotelModels;
using Async_Inn_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Data
{
    public class AsyncInnDbContext : DbContext

    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
             
        }
        //seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(

                new Hotel { ID = 1, Hotel_Name = "Hanan Hotel", Hotel_Street_Address="One Street", Hotel_City="Amman", Hotel_State="Amman", Hotel_Country="Jordan", Hotel_Phone="0781234567" },
                new Hotel { ID = 2, Hotel_Name = "Lojain Hotel", Hotel_Street_Address = "Two Street", Hotel_City = "Ajloun", Hotel_State = "Ajloun", Hotel_Country = "Jordan", Hotel_Phone = "0794312333" },
                new Hotel { ID = 3, Hotel_Name = "Mohammad Hotel", Hotel_Street_Address = "Three Street", Hotel_City = "Jarash", Hotel_State = "Jarash", Hotel_Country = "Jordan", Hotel_Phone = "0778900000" }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, Room_Name = "Seahawks Snooze",Room_Layout="One Bedroom" },
                new Room { ID = 2, Room_Name = "Restful Rainier" , Room_Layout ="Two Bedroom"},
                new Room { ID = 3, Room_Name = "classic Snooze" , Room_Layout="Stodio" }
                );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { ID = 1, Amenity_Name = "Mini bar" },
                new Amenity { ID = 2, Amenity_Name = "ocean view" },
                new Amenity { ID = 3, Amenity_Name = "coffee maker" }
                );
            modelBuilder.Entity<RoomAmenities>().HasKey(
              RoomAmenities => new { RoomAmenities.RoomId , RoomAmenities.AmenityId}
               );
            modelBuilder.Entity<HotelRoom>().HasKey(
           HotelRoom => new { HotelRoom.RoomNumber, HotelRoom.HotelID }
            );
      
        }
    }
}
