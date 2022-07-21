using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.DTOs.Auth
{
    public class RegistrationRequest: Person
    {
        public string Password { get; set; }
    }
}
