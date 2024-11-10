using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanderCamp.Domain.Models;

namespace WanderCampController.APILayer.Model
{
    public class UserRegistrationRequest
    {
        internal string ErrorMessage;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRegistrationRequest()
        {

        }
        public UserRegistrationRequest(User result)
        {
            Id = result.UserId;
        }
    }
}
