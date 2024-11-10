using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderCampController.APILayer.Model
{
    public class UserLoginRequest
    {
        internal string ErrorMessage;

        public string Email { get; set; }
        public string Password { get; set; }
        public Task<string> Token { get; internal set; }
    }
}
