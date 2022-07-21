using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.DTOs.Auth
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public Person User { get; set; }
    }
}
