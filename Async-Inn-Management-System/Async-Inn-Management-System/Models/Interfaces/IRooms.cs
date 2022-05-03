using Async_Inn_Management_System.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Async_Inn_Management_System.Models.DTO.RoomDTO;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IRooms
    {
        Task<Room> Create(NewRoomDTO newRoomDTO);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> GetRoom(int id);
        Task<RoomDTO> UpdateRoom(int id, RoomDTO newroomDTO);
        Task Delete(int id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
