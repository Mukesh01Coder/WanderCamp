using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderCamp.Domain.Models.DTOs
{
    public class UserDTO
    {
        internal string ErrorMessage;

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobilenumber { get; set; }

        public UserDTO() { }

        public UserDTO(int userId, string userName, string email, string mobileNumber)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Mobilenumber = mobileNumber;
        }
    }
}
