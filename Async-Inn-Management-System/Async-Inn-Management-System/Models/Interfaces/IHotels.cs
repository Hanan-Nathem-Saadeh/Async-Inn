using Async_Inn_Management_System.HotelModels;
using Async_Inn_Management_System.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotels
    {
        Task<HotelDTO> Create(HotelDTO hotel);
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotel(int id);
        Task<HotelDTO> UpdateHotel(int id, HotelDTO hotel);
        Task Delete(int id);
    }
}
