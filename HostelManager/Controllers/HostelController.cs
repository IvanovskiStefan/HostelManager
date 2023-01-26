using HostelManager.Domain;
using HostelManager.Services;
using HostelManager.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Linq.Expressions;

namespace HostelManager.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HostelController : ControllerBase
    {
        private readonly IHostelServices _hostelServices;

        public HostelController(IHostelServices hostelServices)
        {
            _hostelServices = hostelServices;
        }


        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Hostel>> getHostels()
        {

            var hostels = _hostelServices.GetAllHostels();
            return Ok(hostels);



        }

        [HttpPost("add-hostel")]
        public ActionResult AddHostel([FromBody] Hostel hostel)
        {
            
                var hostelUrl = _hostelServices.AddHostel(hostel);
                
                
                return Created(hostelUrl, null);
            
            
        }

        [HttpDelete("delete-hostel/{id}")]
        public ActionResult DeleteHostel(int id, int hostelId)
        {
            try 
            { 
                _hostelServices.DeleteHostel(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

        [HttpPost("update-hostel/{id}")]
        public ActionResult UpdateHostel(Hostel hostel)
        {

            _hostelServices.UpdateHostel(hostel);

            return Ok();


        }
    }

}

