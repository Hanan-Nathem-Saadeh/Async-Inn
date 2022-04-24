using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.Interfaces;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRooms _Room;

        public RoomsController(IRooms room)
        {
            _Room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var room = await _Room.GetRooms();
            return Ok(room);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            Room room = await _Room.GetRoom(id);
            return Ok(room);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            var modifiedRoom = await _Room.UpdateRoom(id, room);

            return Ok(modifiedRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            Room newRoom = await _Room.Create(room);
            return Ok(newRoom);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _Room.Delete(id);

            return NoContent();
        }

        //private bool RoomExists(int id)
        //{
        //    return _context.Rooms.Any(e => e.ID == id);
        //}
        // Delete Amentity
        //api/Rooms/5/1
        [HttpDelete("{roomId}/{amenityId}")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _Room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }
        //Add Amentity to room
        //api/Rooms/3/2
        [HttpPost("{roomId}/{amenityId}")]
        public async Task<IActionResult> aAddAmantityToRoom(int roomId, int amenityId)
        {
            await _Room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }
    }
}
