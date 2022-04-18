using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.HotelModels
{
    public class Hotel
    {
     
        public  int ID { get; set; }
        
        public string Hotel_Name { get; set; }
      
        public string Hotel_Street_Address { get; set; }
       
        public string Hotel_City { get; set; }
        
        public string Hotel_State { get; set; }
      
        public string Hotel_Country { get; set; }
       
        public string Hotel_Phone { get; set; } 
    }
}
