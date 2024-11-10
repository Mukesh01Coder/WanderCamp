using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;
using WanderCampRepository.DataAccessLayer.DatabaseContext;
using WanderCampRepository.DataAccessLayer.Interface;

namespace WanderCampRepository.DataAccessLayer.Repository
{
    public class CampgroundRepository : ICampgroundRepository
    {
        private readonly ApplicationDbContext _context;

        public CampgroundRepository(ApplicationDbContext context)
        {
            _context = context;
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
