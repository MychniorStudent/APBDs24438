using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.Application.Implementations;
using RevenueRecognitionSystem.Domain.DTOs.Contract;
using RevenueRecognitionSystem.Domain.DTOs.Revenue;
using RevenueRecognitionSystem.Domain.Interfaces.Services;

namespace RevenueRecognitionSystem_s24438.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;
        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }
        [Authorize]
        [HttpPost]
        public IActionResult GetRevenue(GetRevenueDTO request)
        {
            
            return Ok(_revenueService.GetRevenue(request));
        }
        [Authorize]
        [HttpPost]
        public IActionResult GetPredictedRevenue(GetRevenueDTO request)
        {
           
            return Ok(_revenueService.GetPredictedRevenue(request));
        }
    }
}
