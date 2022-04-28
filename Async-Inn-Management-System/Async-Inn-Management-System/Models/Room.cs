using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.Models
{
    public class Room
    {
        

        public int ID { get; set; }
        public string Room_Name { get; set; }
        public string Room_Layout { get; set; }
        public List<RoomAmenities> RoomAmenity { get; set; }
        public List<HotelRoom> HotelRoom { get; set; }

    }
}
