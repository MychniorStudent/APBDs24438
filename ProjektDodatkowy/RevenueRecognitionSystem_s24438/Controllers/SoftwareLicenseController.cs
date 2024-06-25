using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.Domain.DTOs.Contract;
using RevenueRecognitionSystem.Domain.DTOs.Subscription;
using RevenueRecognitionSystem.Domain.Exceptions;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using RevenueRecognitionSystem.Domain.Models.User;

namespace RevenueRecognitionSystem_s24438.Controllers
{
    //śmiga
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SoftwareLicenseController : ControllerBase
    {
        IContractService _contractService { get; set; }
        ISubscriptionService _subscriptionService { get; set; }
        public SoftwareLicenseController(IContractService contractService, ISubscriptionService subscriptionService)
        {
            _contractService = contractService;
            _subscriptionService = subscriptionService;

        }


        [Authorize]
        [HttpPost]
        public IActionResult CreateContract(CreateContractDTO request)
        {
            try
            {
                _contractService.CreateContract(request);
            }catch (RevenueException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult PayForContract(PayForContractDTO request)
        {
            try 
            { 
                return Ok(_contractService.PayForContract(request));
            }catch (RevenueException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                throw;
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult BuySubscription(BuySubscriptionDTO request)
        {
            try
            {
                _subscriptionService.BuySubscription(request);
            }
            catch (RevenueException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult PayForSubscription(PayForSubscriptionDTO request)
        {
            try
            {
                _subscriptionService.PayForSubscription(request);
            }
            catch (RevenueException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                throw;
            }
            return Ok();
        }
    }
}
