using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WanderCamp.Domain.Models;
using WanderCampController.APILayer.Model;
using WanderCampService.BusinessLogicLayer.Interfaces;

namespace WanderCampController.APILayer.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase // ControllerBase provides essential functionality and tools to handle HTTP requests, generate responses, handle errors, and manage data binding, making it a core component of ASP.NET Core Web API applications
    {
        private readonly IUserService _userService;

        public UserController(IUserService userServerce)
        {
            _userService = userServerce;
        }

        [HttpPost("register")]
        public async Task<UserRegistrationRequest> RegisterAsync(User request)
        {

            if (!ModelState.IsValid)
            {
                return new UserRegistrationRequest { ErrorMessage = "Invalid model state" };
            }


            var result = await _userService.RegisterAsync(request);
            
            return new UserRegistrationRequest(result);
        }

        [HttpPost("login")]
        public async Task<UserLoginRequest> LoginAsync(User request)
        {
            var user = await _userService.AuthenticateAsync(request);
            if (user != null)
            {
                var token = _userService.GenerateJwtTokenAsync(user); // Generate token

                 return new UserLoginRequest { Token = token };
            }

            return new UserLoginRequest { ErrorMessage = "Invalid login credentials" };

        }

        [Authorize]
        [HttpGet("userId")]
        public async Task<UserResponse> GetUserProfileAsync(int userId)
        {
            var user =  await _userService.GetUserProfileAsync(userId);
            if (user != null)
                return new UserResponse(user);

            return new UserResponse { ErrorMessage = "User not found" };
        }

        
    }
}
