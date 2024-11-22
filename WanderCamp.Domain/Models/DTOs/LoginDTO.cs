using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderCamp.Domain.Models.DTOs
{
    public class LoginDTO
    {
        internal string ErrorMessage;

        //public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public LoginDTO() { }
    }
}
