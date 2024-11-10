using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;

namespace WanderCampRepository.DataAccessLayer.Interface
{
    public interface ICampgroundRepository
    {
        Task<Campground> GetAllCampgroundsAsync();
        Task<Campground> GetCampgroundByIdAsync(int campgroundId);
        Task AddCampgroundAsync(Campground campground);
    }
}
