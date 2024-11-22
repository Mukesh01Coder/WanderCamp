using Microsoft.EntityFrameworkCore;
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
        public async Task AddCampgroundAsync(Campground campground)
        {
             _context.Campgrounds.Add(campground);

            await  _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Campground>> GetAllCampgroundsAsync()
        {
            var campgrounds =  await _context.Campgrounds.ToListAsync();

            if (campgrounds == null)
            {
                return new List<Campground> { };
            }
            return campgrounds;
        }

        public async Task<Campground> GetCampgroundByIdAsync(int campgroundId)
        {
            var campground =  await _context.Campgrounds.FindAsync(campgroundId);

            if (campground == null)
            {
                return new Campground();
            }

            return campground;
        }
    }
}
