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
using Async_Inn_Management_System.Models.DTO;
using static Async_Inn_Management_System.Models.DTO.RoomDTO;
using Microsoft.AspNetCore.Authorization;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "DistrictManager")]
    public class RoomsController : ControllerBase
    {
        private readonly IRooms _Room;

        public RoomsController(IRooms room)
        {
            _Room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        [AllowAnonymous]
        // [Authorize(Roles = "PropertyManager, DistrictManager")]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            var room = await _Room.GetRooms();
            return Ok(room);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        // [Authorize(Roles = "PropertyManager, DistrictManager")]
        [AllowAnonymous]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            RoomDTO room = await _Room.GetRoom(id);
            return Ok(room);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "PropertyManager, DistrictManager")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO newroomDTO)
        {
            if (id != newroomDTO.ID)
            {
                return BadRequest();
            }
            var updateRoom = await _Room.UpdateRoom(id, newroomDTO);
            return Ok(updateRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(RoomDTO newRoomDTO)
        {
            RoomDTO newRoom = await _Room.Create(newRoomDTO);
            return Ok(newRoom);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _Room.Delete(id);

            return NoContent();
        }

        
        // Delete Amentity
        //api/Rooms/5/1
        [HttpDelete("{roomId}/{amenityId}")]
        [Authorize(Roles = "PropertyManager, DistrictManager , Agent")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _Room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }
        //Add Amentity to room
        //api/Rooms/3/2
        [HttpPost("{roomId}/{amenityId}")]
        [Authorize(Roles = "PropertyManager, DistrictManager , Agent")]
        public async Task<IActionResult> AddAmantityToRoom(int roomId, int amenityId)
        {
            await _Room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }
    }
}
