
using WanderCamp.Domain.Models;
using WanderCamp.Domain.Models.DTOs;

namespace WanderCampService.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
      Task  RegisterAsync(User request);
      Task<LoginResponseDTO> AuthenticateAsync(LoginDTO request);
      Task<UserDTO> GetUserProfileAsync(int userId);

        string GenerateJwtToken(LoginResponseDTO user);
    }
}
