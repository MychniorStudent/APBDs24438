using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.Domain.DTOs.ClientDTOs;
using RevenueRecognitionSystem.Domain.Exceptions;
using RevenueRecognitionSystem.Domain.Interfaces;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using RevenueRecognitionSystem.Domain.Models.User;

namespace RevenueRecognitionSystem_s24438.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientController : ControllerBase
    {
        IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        
        [Authorize]
        [HttpPost]
        public IActionResult AddIndividualClient(AddIndividualClientDTO request)
        {
            try
            {
                _clientService.AddIndividualClient(request);
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
        public IActionResult AddCompanyClient(AddCompanyClientDTO request)
        {
            try
            {
                _clientService.AddCompanyClient(request);
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditIndividualClient(EditIndividualClientDTO request)
        {
            try
            {
                _clientService.EditIndividualClient(request);
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditCompanyClient(EditCompanyClientDTO request)
        {
            try
            {
                _clientService.EditCompanyClient(request);
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteIndividualClient(Guid id)
        {
            try
            {
                _clientService.DeleteIndividualClient(id);
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
