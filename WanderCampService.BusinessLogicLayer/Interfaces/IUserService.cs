using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;

namespace WanderCampService.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
      Task<User>  RegisterAsync(User request);
      Task<User> AuthenticateAsync(User request);
      Task<User> GetUserProfileAsync(int userId);
      Task<string> GenerateJwtTokenAsync(User user);
    }
}
