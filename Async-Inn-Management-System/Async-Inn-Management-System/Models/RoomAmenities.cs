namespace Async_Inn_Management_System.Models
{
    public class RoomAmenities
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }


    }
}
