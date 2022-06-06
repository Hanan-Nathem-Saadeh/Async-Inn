using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Servieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTest
{
    public class RoomsTest : Mock
    {
        [Fact]
        
            public async void  CreateAndSaveTestAmenity()
            {
            AmenityDTO amenity = new AmenityDTO { Name = "TestAmenityName" };
            var repository = new AmenitiesServieces(_db);
            amenity = await repository.Create(amenity);
             
                Assert.NotEqual(0, amenity.ID); // Sanity check
                
            }
        [Fact]
        public async void CreateAndSaveTestRoom()
        {
            RoomDTO room = new RoomDTO { Name = "testRoomName", Layout = "testRoomLayout" };
            var repository = new RoomsServieces(_db);
            room = await repository.Create(room);

            Assert.NotEqual(0, room.ID); // Sanity check

        }
        [Fact]
        public async void RemoveTestRoom()
        {
            RoomDTO room = new RoomDTO { Name = "testRoomName", Layout = "testRoomLayout" };
            var repository = new RoomsServieces(_db);
            room = await repository.Create(room);
            int x= room.ID;
            Assert.NotEqual(0, room.ID); // Sanity check
            await repository.Delete(room.ID);
            Assert.NotEqual(x,room.ID); // Sanity check


        }
        //  // Arrange
        //  var amenity = await CreateAndSaveTestAmenity();
        //  var room = await CreateAndSaveTestRoom();

        //  var repository = new RoomsServieces(_db);

        //  // Act
        //await repository.AddAmenityToRoom(room.ID,amenity.ID);

        //  // Assert
        //  var actualRoom = await repository.GetRoom(room.ID);

        //  Assert.Contains(actualRoom.Amenities, e => e.ID == room.ID);

        //  //// Act
        //  await repository.RemoveAmentityFromRoom(room.ID, amenity.ID);

        //  //// Assert
        // actualRoom = await repository.GetRoom(room.ID);
        //  Assert.DoesNotContain(actualRoom.Amenities, e => e.ID == room.ID);

    }
}

