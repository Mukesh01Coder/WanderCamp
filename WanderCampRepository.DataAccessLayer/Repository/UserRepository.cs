using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using WanderCamp.Domain.Models;
using WanderCamp.Domain.Models.DTOs;
using WanderCampRepository.DataAccessLayer.DatabaseContext;
using WanderCampRepository.DataAccessLayer.Interface;

namespace WanderCampRepository.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string? _connectionString;
        private readonly ApplicationDbContext _context;
        

        public UserRepository(IConfiguration configuration,ApplicationDbContext context)
        {
            _connectionString = configuration.GetConnectionString("DBConnection");
            _context = context;
        }


        public async Task<LoginResponseDTO> AuthenticateAsync(LoginDTO request)
        {
           
                var connection = new SqlConnection(_connectionString);
                using (var command = new SqlCommand("VerifyUserCredentials", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", request.UserName);
                    command.Parameters.AddWithValue("@password", request.Password);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new LoginResponseDTO
                            {
                               UserId = reader.GetInt32(0),
                               UserName = reader.GetString(1),
                               Email = reader.GetString(2),
                               MobileNumber = reader.GetString(3),
                            };
                        }
                    }
                }        
           
            return null;
        }

        public async Task<UserDTO> GetUserProfileAsync(int userId)
        {

            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return new UserDTO();
            }
            return new UserDTO(user.UserId, user.UserName, user.Email, user.MobileNumber);
        }

        public async Task RegisterAsync(User request)
        {
            _context.Users.Add(request);

            await _context.SaveChangesAsync();
        }

    }
}
