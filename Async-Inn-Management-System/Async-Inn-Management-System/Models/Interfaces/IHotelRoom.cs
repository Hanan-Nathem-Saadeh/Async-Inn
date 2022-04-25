using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(int HoteID, HotelRoom hotelRoom);
        Task<List<HotelRoom>> GetHotelRooms();
        Task<HotelRoom> GetHotelRoom(int HotelId, int RoomNum);
        Task<HotelRoom> UpdateHotelRoom(int HotelId, int RoomNum, HotelRoom hotelRoom);
        Task Delete(int HotelId, int RoomNum);
    }
}
