using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Async_Inn_Management_System.Models.Servieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTest
{
    public class AmenityTest : Mock
    {
        private IAmentities CallService()
        {
            return new AmenitiesServieces(_db);
        }
        [Fact]
        public async Task CreateAndSaveAmenity()
        {
            var NewAmenity = new AmenityDTO
            {
                ID= 4,
                Name="TestCreate"
            };
            var Service = CallService();
            var AddedAmenity = Service.Create(NewAmenity);
            Assert.NotNull(AddedAmenity);
            Assert.NotEqual(0, AddedAmenity.Id);
        }
      
        [Fact]
        public async void GetAmenities()
        {
            AmenityDTO Amenity = new AmenityDTO { ID = 4, Name = "TestAmenity1" };
            AmenityDTO Amenity2 = new AmenityDTO { ID = 5, Name = "TestAmenity2" };
            
            var repository = new AmenitiesServieces(_db);
            Amenity = await repository.Create(Amenity);
            Amenity2 = await repository.Create(Amenity2);
            List<AmenityDTO> GetAmenityList = await repository.GetAmenities();

            Assert.Equal(5, GetAmenityList.Count);
        }
        [Fact]
        public async void GetAmenityById()
        {
            AmenityDTO Amenity = new AmenityDTO { ID = 4, Name = "TestAmenity1" };
            //AmenityDTO Amenity2 = new AmenityDTO { ID = 5, Name = "TestAmenity2" };

            var repository = new AmenitiesServieces(_db);
            Amenity = await repository.Create(Amenity);

            var GetAmenity = await repository.GetAmenity(4);

            Assert.Equal("TestAmenity1", GetAmenity.Name);
        }
        [Fact]
        public async void RemoveAmenityTest()
        {
            AmenityDTO Amenity = new AmenityDTO { ID = 4, Name = "TestAmenity1" };
            var repository = new AmenitiesServieces(_db);
            Amenity = await repository.Create(Amenity);
      
            List<AmenityDTO> mylist = await repository.GetAmenities();
            Assert.Equal(4, mylist.Count);
            await repository.Delete(Amenity.ID);
            List<AmenityDTO> mylist2 = await repository.GetAmenities();
            Assert.Equal(3, mylist2.Count);


        }


    }
}
