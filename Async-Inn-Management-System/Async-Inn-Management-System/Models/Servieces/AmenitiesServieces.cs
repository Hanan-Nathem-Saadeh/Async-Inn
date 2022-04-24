
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Async_Inn_Management_System.Models.Servieces
{
    public class AmenitiesServieces : IAmentities
    {
        private readonly AsyncInnDbContext _context;

        public AmenitiesServieces(AsyncInnDbContext context)
        {
            _context = context;
        }
       

        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);

            _context.Entry(amenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities.Include(x => x.RoomAmenity)
                                           .ThenInclude(x => x.Room)
                                           .ToListAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {

            return await _context.Amenities.Include(x => x.RoomAmenity)
                                           .ThenInclude(x => x.Room)
                                           .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return amenity;
        }
    }
}
