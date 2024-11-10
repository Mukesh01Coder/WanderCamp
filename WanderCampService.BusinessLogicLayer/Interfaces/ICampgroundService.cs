using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;

namespace WanderCampService.BusinessLogicLayer.Interfaces
{
    public interface ICampgroundService
    {
        Task<Campground> GetAllCampgroundsAsync();
        Task<Campground> GetCampgroundByIdAsync(int campgroundId);
        Task AddCampgroundAsync(Campground campground);
    }
}
