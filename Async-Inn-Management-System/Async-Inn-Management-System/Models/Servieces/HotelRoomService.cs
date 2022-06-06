using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Servieces

{
    public class HotelRoomService : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;
        public HotelRoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoomDTO> Create(int HoteID, HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom newHotelRoom = new HotelRoom
            {
                HotelID = hotelRoomDTO.HotelID,
                RoomNumber = hotelRoomDTO.RoomNumber,
                Rate = (int)hotelRoomDTO.Rate,
                PetFriendly = hotelRoomDTO.PetFriendly,
                RoomID = hotelRoomDTO.RoomID
            };
            _context.Entry(newHotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoomDTO;
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
        {
            return await _context.HotelRoom.Select(x => new HotelRoomDTO()
            {
                HotelID = x.HotelID,
                RoomNumber = x.RoomNumber,
                Rate = x.Rate,
                PetFriendly = x.PetFriendly,
                RoomID = x.RoomID,
                Room = new RoomDTO()
                {
                    ID = x.Room.ID,
                    Name = x.Room.Room_Name,
                    Layout = x.Room.Room_Layout,
                    Amenities = x.Room.RoomAmenity
                    .Select(ra => new AmenityDTO()
                    {
                        ID = ra.Amenity.ID,
                        Name = ra.Amenity.Amenity_Name
                    }).ToList()
                }
            }).FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomNumber == roomNumber);

            //return await _context.HotelRoom.Include(x => x.Room)
            //                                .ThenInclude(c => c.RoomAmenity)
            //                                .Include(x => x.Hotel)
            //                                .ThenInclude(e => e.HotelRoom)
            //                                .FirstOrDefaultAsync(x => x.HotelID == HotelId && x.RoomNumber == RoomNum); 
        }



        public async Task Delete(int HotelId, int RoomNum)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(HotelId, RoomNum);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            return await _context.HotelRoom.Select(x => new HotelRoomDTO()
            {
                HotelID = x.HotelID,
                RoomNumber = x.RoomNumber,
                Rate = x.Rate,
                PetFriendly = x.PetFriendly,
                RoomID = x.RoomID,
                Room = new RoomDTO()
                {
                    ID = x.Room.ID,
                    Name = x.Room.Room_Name,
                    Layout = x.Room.Room_Layout,
                    Amenities = x.Room.RoomAmenity
                  .Select(ra => new AmenityDTO()
                  {
                      ID = ra.Amenity.ID,
                      Name = ra.Amenity.Amenity_Name
                  })
                   .ToList()
                }
            }).ToListAsync();
            //return await _context.HotelRoom.Include(x => x.Room)
            //                                .ThenInclude(a => a.RoomAmenity)
            //                                .Include(x => x.Hotel)
            //                                .ThenInclude(r => r.HotelRoom)
            //.ToListAsync(); 
        }

        public async Task<HotelRoomDTO> Update(int hotelId, int roomNumber, HotelRoomDTO updateHotelRoomDTO)
        {
            HotelRoom updateHotelRoom = new HotelRoom
            {
                HotelID = updateHotelRoomDTO.HotelID,
                RoomNumber = updateHotelRoomDTO.RoomNumber,
                Rate = (int)updateHotelRoomDTO.Rate,
                PetFriendly = updateHotelRoomDTO.PetFriendly,
                RoomID = updateHotelRoomDTO.RoomID
            };
            _context.Entry(updateHotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateHotelRoomDTO;
        }

    }
}