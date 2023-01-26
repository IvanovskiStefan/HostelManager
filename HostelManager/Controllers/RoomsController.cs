using HostelManager.Domain;
using HostelManager.Services;
using HostelManager.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HostelManager.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoomsController:ControllerBase
    {
        private readonly IRoomsService _roomsServices;

        public RoomsController(IRoomsService roomsServices)
        {
            _roomsServices = roomsServices;
        }

        [HttpGet("get-all-rooms")]
        public ActionResult<IEnumerable<Room>> getRooms()
        {

            var rooms = _roomsServices.GetAllRooms();
            return Ok(rooms);



        }

        [HttpPost("add-room")]
        public ActionResult Addroom([FromBody] Room room)
        {

            var roomUrl = _roomsServices.AddRooms(room);


            return Created(roomUrl, null);


        }

        [HttpDelete("delete-room/{id}")]
        public ActionResult DeleteHostel(int id, int hostelId)
        {
            try
            {
                _roomsServices.DeleteRooms(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
    }
}
