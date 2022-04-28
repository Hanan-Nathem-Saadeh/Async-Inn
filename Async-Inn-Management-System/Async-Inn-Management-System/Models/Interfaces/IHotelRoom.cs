using Async_Inn_Management_System.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> Create(int HoteID, HotelRoomDTO hotelRoom);
        Task<List<HotelRoomDTO>> GetHotelRooms();
        Task<HotelRoomDTO> GetHotelRoom(int HotelId, int RoomNum);
        Task<HotelRoomDTO> Update(int hotelId, int roomNumber, HotelRoomDTO HotelRoomDTO);
        Task Delete(int HotelId, int RoomNum);
    }
}
