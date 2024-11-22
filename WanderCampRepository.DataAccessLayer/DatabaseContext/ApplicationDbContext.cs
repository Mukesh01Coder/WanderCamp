using Microsoft.EntityFrameworkCore;

using WanderCamp.Domain.Models;

namespace WanderCampRepository.DataAccessLayer.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Campground> Campgrounds { get; set; }

    }
}
