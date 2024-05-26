using Microsoft.AspNetCore.Mvc;
using TripApp.DTOs;
using TripApp.Interfaces;
using TripApp.Models;

namespace TripApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class TripController : ControllerBase
    {
        ITripRepository _tripRepository;
        public TripController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        [HttpGet("trips")]
        public async Task<ActionResult> trips()
        {
            return Ok( await _tripRepository.getTrips());
        }
        [HttpDelete("clients/{idClient}")]
        public async Task<ActionResult> clients(int idClient) 
        {
            try
            {
                var resposne = await _tripRepository.deleteClientById(idClient);
                return Ok(resposne);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("trips/{idTrip}/clients")]
        public async Task<ActionResult> clients([FromBody] ClientTripAssignDTO inputBody, int idTrip)
        {
            try
            {
                if (idTrip != inputBody.IdTrip)
                    return BadRequest("Id tripow z body i query są rozne!");
                return Ok(await _tripRepository.assignClientToTrip(inputBody));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
