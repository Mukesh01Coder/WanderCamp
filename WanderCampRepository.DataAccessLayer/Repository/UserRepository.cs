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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

            public UserRepository(ApplicationDbContext context) 
            {
              _context = context;
            }


            public Task<User> AuthenticateAsync(User request)
            {
                throw new NotImplementedException();
            }

            public Task<User> GetUserProfileAsync(int userId)
            {
                throw new NotImplementedException();
            }

            public Task<User> RegisterAsync(User request)
            {
                throw new NotImplementedException();
            }
        
    }
}
