using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Models.DTO;

namespace Async_Inn_Management_System.Models.Servieces
{
    public class AmenitiesServieces : IAmentities
    {
        private readonly AsyncInnDbContext _context;

        public AmenitiesServieces(AsyncInnDbContext context)
        {
            _context = context;
        }


        public async Task<AmenityDTO> Create(AmenityDTO NewmAmentityDTO)
        {
            Amenity newAmenity = new Amenity
            {
                Amenity_Name = NewmAmentityDTO.Name
            };
            _context.Entry(newAmenity).State = EntityState.Added;

            await _context.SaveChangesAsync();
            AmenityDTO amentityDto = await GetAmenity(newAmenity.ID);
            return amentityDto;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);

            _context.Entry(amenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            //return await _context.Amenities.Include(x => x.RoomAmenity)
            //                               .ThenInclude(x => x.Room)
            //                               .ToListAsync();
            return await _context.Amenities
             .Select(Amenity => new AmenityDTO
             {
                 ID = Amenity.ID,
                 Name = Amenity.Amenity_Name
             }).ToListAsync();
        }


        public async Task<AmenityDTO> GetAmenity(int id)
        {

            //return await _context.Amenities.Include(x => x.RoomAmenity)
            //                               .ThenInclude(x => x.Room)
            //                               .FirstOrDefaultAsync(x => x.ID == id);
            return await _context.Amenities
                .Select(Amenity => new AmenityDTO
                {
                    ID = Amenity.ID,
                    Name = Amenity.Amenity_Name


                }).FirstOrDefaultAsync(s => s.ID == id);

        }

        public async Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO newAmentity)
        {
            Amenity NewMantity = new Amenity
            {
                ID = newAmentity.ID,
                Amenity_Name = newAmentity.Name
            };
            _context.Entry(NewMantity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return newAmentity;
        }
    }
}