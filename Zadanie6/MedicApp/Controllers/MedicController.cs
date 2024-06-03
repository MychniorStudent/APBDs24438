using MedicApp.DTOs;
using MedicApp.Interfaces;
using MedicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicController : ControllerBase
    {
        IMedicService _medicService;
        public MedicController(IMedicService medicService)
        {
            _medicService = medicService;
        }
        [HttpGet]
        public async Task<ActionResult> GetPatientData([FromQuery] int patientId)
        {
            try
            {
                return Ok(await _medicService.GetPatientDataById(patientId));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNewPerscription([FromBody] AddPerscriptionRequest request)
        {

            try
            {
                return Ok(await _medicService.AddPerscription(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
