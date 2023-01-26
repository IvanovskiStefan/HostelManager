using HostelManager.Domain;
using HostelManager.Services;
using HostelManager.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HostelManager.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GuestController:ControllerBase
    {
        private readonly IGuestService _guestServices;

        public GuestController(IGuestService guestlServices)
        {
            _guestServices = guestlServices;
        }


        [HttpGet("get-all-guests")]
        public ActionResult<IEnumerable<Guest>> getGuest()
        {

            var guests = _guestServices.GetAllGuests();
            return Ok(guests);



        }

        [HttpPost("add-guest")]
        public ActionResult AddGuest([FromBody] Guest guest)
        {

            var guestUrl = _guestServices.AddGuest(guest);


            return Created(guestUrl, null);


        }

        [HttpDelete("delete-guest/{id}")]
        public ActionResult DeleteGuest(int id)
        {
            //try
            //{
                _guestServices.DeleteGuest(id);
                return StatusCode(StatusCodes.Status204NoContent);
            //}

            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}



        }

    }
}
