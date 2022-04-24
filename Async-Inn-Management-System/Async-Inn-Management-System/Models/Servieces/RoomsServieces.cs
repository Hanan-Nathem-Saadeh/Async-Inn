using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System.Models.Servieces
{
    public class RoomsServieces : IRooms
    {
        private readonly AsyncInnDbContext _context;

        public RoomsServieces(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomId = roomId,
                AmentityId = amenityId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removeAmentity = _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == roomId && x.AmentityId == amenityId);
            _context.Entry(removeAmentity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);

            _context.Entry(room).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.Include(x => x.RoomAmenity)
                                      .ThenInclude(e => e.Amenity)
                                      .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.Include(x => x.RoomAmenity)
                                          .ThenInclude(e => e.Amenity)
                                          .ToListAsync();
        }

      

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return room;
        }
    }
}
