using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.HotelModels;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Servieces
{
    public class HotelServieces : IHotels
    {
        private readonly AsyncInnDbContext _context;

        public HotelServieces(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return hotel;
        }




        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);

            _context.Entry(hotel).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            return await _context.Hotels.Select(x => new HotelDTO
            {
                ID = x.ID,
                Name = x.Hotel_Name,
                StreetAddress = x.Hotel_Street_Address,
                City = x.Hotel_City,
                State = x.Hotel_State,
                Phone = x.Hotel_Phone,
                Rooms = x.HotelRoom.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    RoomID = x.RoomID,
                    Room = new RoomDTO
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Room_Name,
                        Layout = x.Room.Room_Layout,

                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                        {
                            ID = x.AmenityId,
                            Name = x.Amenity.Amenity_Name
                        }).ToList()
                    }
                    }).ToList()
           

                 
                    }).FirstOrDefaultAsync(x => x.ID == id);
        
        }


        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.Hotels.Select(x => new HotelDTO
            {
                ID = x.ID,
                Name = x.Hotel_Name,
                StreetAddress = x.Hotel_Street_Address,
                City = x.Hotel_City,
                State = x.Hotel_State,
                Phone = x.Hotel_Phone,
                Rooms = x.HotelRoom.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    RoomID = x.RoomID,
                    Room = new RoomDTO
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Room_Name,
                        Layout = x.Room.Room_Layout,

                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                        {
                            ID = x.AmenityId,
                            Name = x.Amenity.Amenity_Name
                        }).ToList()
                    }
                }).ToList()



            }).ToListAsync();
        }


        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return hotel;
        }

    }
}
