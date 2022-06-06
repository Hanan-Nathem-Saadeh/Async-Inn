using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;
        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
        //protected async Task<Amenity> CreateAndSaveTestAmenity()
        //{
        //    var ameity = new Amenity { Amenity_Name = "TestAmenityName"};
        //    _db.Amenities.Add(ameity);
        //    await _db.SaveChangesAsync();
        //    Assert.NotEqual(0, ameity.ID); // Sanity check
        //    return ameity;
        //}


        //protected async Task<Room> CreateAndSaveTestRoom()
        //{
        //    var room = new Room {Room_Name = "testRoomName", Room_Layout = "testRoomLayout" };
        //    _db.Rooms.Add(room);
        //    await _db.SaveChangesAsync();
        //    Assert.NotEqual(0, room.ID); // Sanity check
        //    return room;
        //}
    }
}
