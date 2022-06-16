using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.Interfaces;
using Async_Inn_Management_System.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "DistrictManager")]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmentities _amentity;

        public AmenitiesController(IAmentities amentity)
        {
            _amentity = amentity;
        }

        // GET: api/Amenities
        [HttpGet]
         [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            var amenities = await _amentity.GetAmenities();
            return Ok(amenities);
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            AmenityDTO amenity = await _amentity.GetAmenity(id);
            return Ok(amenity);

            
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, AmenityDTO newAmenity)
        {
            if (id != newAmenity.ID)
            {
                return BadRequest();
            }
            var updateAmenity = await _amentity.UpdateAmenity(id, newAmenity);
            return Ok(updateAmenity);

        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {
            AmenityDTO newAmentity = await _amentity.Create(amenity);
            return Ok(newAmentity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {

            await _amentity.Delete(id);

            return NoContent();
        }

        
    }
}
