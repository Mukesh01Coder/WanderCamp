using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;
using WanderCampRepository.DataAccessLayer.Interface;
using WanderCampService.BusinessLogicLayer.Interfaces;

namespace WanderCampService.BusinessLogicLayer.Services
{
    public class CampgroundService : ICampgroundService
    {
        private readonly ICampgroundRepository _repository;

        public CampgroundService(ICampgroundRepository repository)
        {
            _repository = repository;
        }
        public async Task AddCampgroundAsync(Campground campground)
        {
           await _repository.AddCampgroundAsync(campground);
        }

        public async Task<IEnumerable<Campground>> GetAllCampgroundsAsync()
        {
            var camgrounds = await _repository.GetAllCampgroundsAsync();

            return camgrounds;
        }

        public async Task<Campground> GetCampgroundByIdAsync(int campgroundId)
        {
            var campground = await _repository.GetCampgroundByIdAsync(campgroundId);

            return campground;
        }
    }
}
