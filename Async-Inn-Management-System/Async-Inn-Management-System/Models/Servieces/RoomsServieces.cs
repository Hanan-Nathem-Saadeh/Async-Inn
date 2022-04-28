using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Models.DTO;
using static Async_Inn_Management_System.Models.DTO.RoomDTO;

namespace Async_Inn_Management_System.Models.Servieces
{
    public class RoomsServieces : IRooms
    {
        private readonly AsyncInnDbContext _context;
        private readonly IAmentities _amentity;
        public RoomsServieces(AsyncInnDbContext context,IAmentities amentity )
        {
            _context = context;
            _amentity = amentity;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomId = roomId,
                AmenitiesId = amenityId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removeAmentity = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == roomId && x.AmenitiesId == amenityId);
            _context.Entry(removeAmentity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> Create(NewRoomDTO newRoomDTO)
        {
            //_context.Entry(room).State = EntityState.Added;

            //await _context.SaveChangesAsync();
            //return room;

            Room newRoom = new Room
            {
                Room_Layout= newRoomDTO.Layout,
                Room_Name = newRoomDTO.Name
            };
            _context.Entry(newRoom).State = EntityState.Added;

            await _context.SaveChangesAsync();
           
            RoomDTO roomDto = await GetRoom(newRoom.ID);
            return roomDto;
        }

        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);

            _context.Entry(room).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            //return await _context.Rooms.Include(x => x.RoomAmenity)
            //                          .ThenInclude(e => e.Amenity)
            //                          .FirstOrDefaultAsync(x => x.ID == id);
            return await _context.Rooms
               .Select(Room => new RoomDTO
               {
                   ID = Room.ID,
                   Name = Room.Room_Name,
                    Layout = Room.Room_Layout,
                    // Amenities = Room.RoomAmenity
                    //.Select(x => new AmenityDTO
                    //{
                    //    ID = x.Amenity.ID,
                    //    Name = x.Amenity.Amenity_Name
                    //}).ToList()
               }).FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            //return await _context.Rooms.Include(x => x.RoomAmenity)
            //                              .ThenInclude(e => e.Amenity)
            //                              .ToListAsync();
            return await _context.Rooms
              .Select(Room => new RoomDTO
              {
                  ID = Room.ID,
                  Name = Room.Room_Name,
                  Layout=Room.Room_Layout
              }).ToListAsync();
        }

      

        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO newroomDTO)
        {
            _context.Entry(newroomDTO).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return newroomDTO;
        }
    }
}
