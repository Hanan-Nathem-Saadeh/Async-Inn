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

        public async Task<HotelDTO> Create(HotelDTO newHotelDTO)
        {
            Hotel newHotel = new Hotel
            {
                ID = newHotelDTO.ID,
                Hotel_Name = newHotelDTO.Name,
                Hotel_Street_Address = newHotelDTO.StreetAddress,
                Hotel_City = newHotelDTO.City,
                Hotel_State = newHotelDTO.State,
                Hotel_Phone = newHotelDTO.Phone
            };
            _context.Entry(newHotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newHotelDTO;
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
                    Room = x.Room.HotelRoom.Select(x => new RoomDTO
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Room_Name,
                        Layout = x.Room.Room_Layout,
                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                        {
                            ID = x.Amenity.ID,
                            Name = x.Amenity.Amenity_Name
                        }).ToList()
                    }).FirstOrDefault()
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
                    Room = x.Room.HotelRoom.Select(x => new RoomDTO
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Room_Name,
                        Layout = x.Room.Room_Layout,
                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                        {
                            ID = x.Amenity.ID,
                            Name = x.Amenity.Amenity_Name
                        }).ToList()
                    }).FirstOrDefault()
                }).ToList()
            }).ToListAsync();
        }


        public async Task<HotelDTO> UpdateHotel(int id, HotelDTO newHotelDTO)
        {
            Hotel updateHotel = new Hotel
            {
                ID = newHotelDTO.ID,
                Hotel_Name = newHotelDTO.Name,
                Hotel_Street_Address = newHotelDTO.StreetAddress,
                Hotel_City = newHotelDTO.City,
                Hotel_State = newHotelDTO.State,
                Hotel_Phone = newHotelDTO.Phone
            };
            _context.Entry(updateHotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return newHotelDTO;
        }

    }
}
