using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WanderCamp.Domain.Models;
using WanderCamp.Domain.Models.DTOs;
using WanderCampService.BusinessLogicLayer.Interfaces;

namespace WanderCampController.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CampgroundController: ControllerBase
    {
        private readonly ICampgroundService _campgroundService;

        public CampgroundController(ICampgroundService campgroundService, IUserService userService)
        {
            _campgroundService = campgroundService;
            
        }

        // Accessible without authentication, if you want to make campgrounds visible to everyone
        [HttpGet("GetAllCampgrounds")]
       
        public async Task<IEnumerable<Campground>> GetAllCampgroundsAsync()
        {
            
            var campgrounds = await _campgroundService.GetAllCampgroundsAsync();

            return campgrounds;
        }

        [HttpGet("GetCampgroundById/{campgroundId}")]
        public async Task<Campground> GetCampgroundByIdAsync(int campgroundId)
        {
            var campground = await _campgroundService.GetCampgroundByIdAsync(campgroundId);

            if (campground == null)
            {
                return new Campground(); 
            }
            return campground;
        }

        // Requires authentication to add a new campground
        [HttpPost("AddCampground")]
        public async Task<Campground> AddCampgroundAsync([FromBody] Campground campground)
        {
            await _campgroundService.AddCampgroundAsync(campground);

            return campground;
        }


    }
}
