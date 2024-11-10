using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;
using WanderCampController.APILayer.Model;
using WanderCampService.BusinessLogicLayer.Interfaces;

namespace WanderCampController.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Apply authorization to all endpoints by default 
    public class CampgroundController: ControllerBase
    {
        private readonly ICampgroundService _campgroundService;

        public CampgroundController(ICampgroundService campgroundService)
        {
            _campgroundService = campgroundService;
        }

        // Accessible without authentication, if you want to make campgrounds visible to everyone
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<CampgroundRequest>> GetAllCampgroundsAsync()
        {
            var campgrounds = await _campgroundService.GetAllCampgroundsAsync();

            return new List<CampgroundRequest> ((IEnumerable<CampgroundRequest>)campgrounds);
        }

        [HttpGet("{campgroundId}")]
        [AllowAnonymous]
        public async Task<CampgroundRequest> GetCampgroundByIdAsync(int campgroundId)
        {
            var campground = await _campgroundService.GetCampgroundByIdAsync(campgroundId);

            if (campground == null)
            {
                return new CampgroundRequest { ErrorMessage = "Camground Not Found!" };
            }
            return new CampgroundRequest(campground);
        }

        // Requires authentication to add a new campground
        [HttpPost]
        public async Task<CampgroundRequest> AddCampgroundAsync([FromBody] Campground campground)
        {
            await _campgroundService.AddCampgroundAsync(campground);

            return new CampgroundRequest(campground);
        }


    }
}
