using Microsoft.AspNetCore.Mvc;
using WanderCamp.Domain.Models.DTOs;
using WanderCampService.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using WanderCamp.Domain.Models;

namespace WanderCampController.APILayer.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet("GetUserProfile")]
        public async Task<UserDTO> GetUserProfileAsync(int userId)
        {
            
            var user = await _userService.GetUserProfileAsync(userId);

            return user;
        }


        [HttpPost("Register")]
        public async Task<User> RegisterAsync([FromBody] User request)
        {
            await _userService.RegisterAsync(request);

            return request;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> LoginAsync([FromBody] LoginDTO request)
        {
            var user = await _userService.AuthenticateAsync(request);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _userService.GenerateJwtToken(user);

            return Ok(new { Token = token });

        }
    }
}
