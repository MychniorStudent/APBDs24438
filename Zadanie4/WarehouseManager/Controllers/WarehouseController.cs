using Microsoft.AspNetCore.Mvc;
using WarehouseManager.DTOs;
using WarehouseManager.Interfaces;

namespace WarehouseManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        [HttpPost("standard")]
        public async Task<ActionResult> DoStuff([FromBody] WarehouseActionDTO data)
        {
            try
            {
                int result = await _warehouseService.doStuff(data);
                if (result > 0)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return BadRequest();
        }

        [HttpPost("extra")]
        public async Task<ActionResult> DoStuffUsingProc([FromBody] WarehouseActionDTO data)
        {
            try
            {
                int result = await _warehouseService.doStuff(data);
                if (result > 0)
                    return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            return BadRequest();
        }
    }
}
