using Async_Inn_Management_System.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IAmentities
    {
        Task<AmenityDTO> Create(AmenityDTO amenity);
        Task<List<AmenityDTO>> GetAmenities();
        Task<AmenityDTO> GetAmenity(int id);
        Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO newamenity);
        Task Delete(int id);
    }
}
