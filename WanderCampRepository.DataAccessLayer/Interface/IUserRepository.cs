using WanderCamp.Domain.Models;
using WanderCamp.Domain.Models.DTOs;
namespace WanderCampRepository.DataAccessLayer.Interface
{
    public interface IUserRepository
    {
       Task RegisterAsync(User request);
       Task<LoginResponseDTO> AuthenticateAsync(LoginDTO request);
       Task<UserDTO>  GetUserProfileAsync(int  userId);

    }
}
