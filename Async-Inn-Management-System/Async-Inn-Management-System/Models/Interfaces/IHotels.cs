using Async_Inn_Management_System.HotelModels;
using Async_Inn_Management_System.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotels
    {
        Task<Hotel> Create(Hotel hotel);
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotel(int id);
        Task<Hotel> UpdateHotel(int id, Hotel hotel);
        Task Delete(int id);
    }
}
