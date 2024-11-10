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
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> AuthenticateAsync(User request)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateJwtTokenAsync(User user)
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
