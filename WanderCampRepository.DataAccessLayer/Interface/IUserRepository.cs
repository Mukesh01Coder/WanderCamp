using WanderCamp.Domain.Models;
namespace WanderCampRepository.DataAccessLayer.Interface
{
    public interface IUserRepository
    {
       Task<User> RegisterAsync(User request);
       Task<User> AuthenticateAsync(User request);
       Task<User>  GetUserProfileAsync(int  userId);

    }
}
