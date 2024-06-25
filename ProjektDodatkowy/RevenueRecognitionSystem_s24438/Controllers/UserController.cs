using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognitionSystem.Domain.DTOs;
using RevenueRecognitionSystem.Domain.Enums;
using RevenueRecognitionSystem.Domain.Interfaces.Services;
using RevenueRecognitionSystem.Domain.Models.User;

namespace RevenueRecognitionSystem_s24438.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RevenueRecognitionSystem.Domain.Models.User.RegisterRequest request)
        {
            try
            {
                _userService.RegisterUser(request, UserRoles.User);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterAdmin([FromBody] RevenueRecognitionSystem.Domain.Models.User.RegisterRequest request)
        {
            try
            {
                _userService.RegisterUser(request, UserRoles.Admin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult LoginUser(RevenueRecognitionSystem.Domain.Models.User.LoginRequest request)
        {
            JWTResponse response;
            try
            {
                response = _userService.LoginUser(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }
        [Authorize(AuthenticationSchemes = "IgnoreTokenExpirationScheme")]
        [HttpPost("refresh")]
        public IActionResult Refresh(RefreshTokenRequest refreshToken)
        {
            return Ok(_userService.Refresh(refreshToken));
        }

        [Authorize(Roles = "user")]
        [HttpPost("refreshTWO")]
        public IActionResult Refresh2(RefreshTokenRequest refreshToken)
        {
            return Ok("_userService.Refresh(refreshToken)");
        }
    }
}
