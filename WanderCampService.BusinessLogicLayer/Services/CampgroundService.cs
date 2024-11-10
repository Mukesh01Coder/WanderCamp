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
        public Task AddCampgroundAsync(Campground campground)
        {
            throw new NotImplementedException();
        }

        public Task<Campground> GetAllCampgroundsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Campground> GetCampgroundByIdAsync(int campgroundId)
        {
            throw new NotImplementedException();
        }
    }
}
