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
        public async void CreateAndSaveTestRoom()
        {
            RoomDTO room = new RoomDTO {ID=1, Name = "testRoomName", Layout = "testRoomLayout" };
            var repository = new RoomsServieces(_db);
            room = await repository.Create(room);

            Assert.NotEqual(0, room.ID);

        }
        [Fact]
        public async void GetRooms()
        {
            RoomDTO room = new RoomDTO { ID = 1, Name = "testRoomName", Layout = "testRoomLayout" };
            RoomDTO room2 = new RoomDTO { ID = 2, Name = "testRoomName2", Layout = "testRoomLayout2" };
            var repository = new RoomsServieces(_db);
            room = await repository.Create(room);
            room = await repository.Create(room2);
            List<RoomDTO> GetRoomsList = await repository.GetRooms();

            Assert.Equal(5, GetRoomsList.Count);
        }
        [Fact]
        public async void GetRoomById()
        {
            RoomDTO room = new RoomDTO { ID = 4, Name = "testRoomName", Layout = "testRoomLayout" };
            
            var repository = new RoomsServieces(_db);
            await repository.Create(room);
           
            var GetRoom = await repository.GetRoom(4);

            Assert.Equal("testRoomName", GetRoom.Name);
        }
        [Fact]
        public async void RemoveTestRoom()
        {
            RoomDTO room = new RoomDTO { Name = "testRoomName", Layout = "testRoomLayout" };
            var repository = new RoomsServieces(_db);
            room = await repository.Create(room);
            int x = room.ID;
            Assert.Equal(4, room.ID);
            List<RoomDTO> mylist = await repository.GetRooms();
            Assert.Equal(4,mylist.Count);
          await repository.Delete(room.ID);
            List<RoomDTO> mylist2 = await repository.GetRooms();
            Assert.Equal(3, mylist2.Count);


        }

    }
  

    }


