using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<HotelRoom> GetHotelRoom(int HotelId, int RoomNum)
        {
            return await _context.HotelRoom.Include(x => x.Room)
                                            .ThenInclude(c => c.RoomAmenity)
                                            .Include(x => x.Hotel)
                                            .ThenInclude(e => e.HotelRoom)
                                            .FirstOrDefaultAsync(x => x.HotelID == HotelId && x.RoomNumber == RoomNum); 
        }
        public async Task Delete(int HotelId, int RoomNum)
        {
            HotelRoom hotelRoom = await GetHotelRoom(HotelId, RoomNum);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRoom.Include(x => x.Room)
                                            .ThenInclude(a => a.RoomAmenity)
                                            .Include(x => x.Hotel)
                                            .ThenInclude(r => r.HotelRoom)
                                            .ToListAsync(); 
        }

        public async Task<HotelRoom> UpdateHotelRoom(int HotelId, int RoomNum, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
      
    }
}
