using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.HotelModels;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            Hotel hotel = await GetHotel(id);

            _context.Entry(hotel).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.Include(c => c.HotelRoom)
                                           .ThenInclude(e => e.Room)
                                           .ThenInclude(h => h.RoomAmenity)
                                           .ThenInclude(r => r.Amenity)
                                           .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.Include(x => x.HotelRoom)
                                            .ThenInclude(e => e.Room)
                                            .ThenInclude(c => c.RoomAmenity)
                                            .ThenInclude(a => a.Amenity)
                                            .ToListAsync();
        }
        

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return hotel;
        }
       
    }
}
