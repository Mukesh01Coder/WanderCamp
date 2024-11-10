using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;

namespace WanderCampController.APILayer.Model
{
    public  class UserResponse
    {
        internal string ErrorMessage;

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserResponse()
        {

        }

        public UserResponse(User user)
        {
            UserId = user.UserId;
            Name = user.UserName;
            Email = user.Email;
        }
    }
}
