using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.Models
{
    public class Amenity
    {
        

        public int ID  { get; set; }
        
        public string Amenity_Name { get; set; }

        public List<RoomAmenities> RoomAmenity { get; set; }
    }
}
