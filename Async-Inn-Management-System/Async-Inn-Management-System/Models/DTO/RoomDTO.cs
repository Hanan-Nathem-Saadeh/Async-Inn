using System.Collections.Generic;

namespace Async_Inn_Management_System.Models.DTO
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
        public class NewRoomDTO
        {
            public string Name { get; set; }
            public string Layout { get; set; }
            public List<AmenityDTO> Amenities { get; set; }
        }
    }
}
