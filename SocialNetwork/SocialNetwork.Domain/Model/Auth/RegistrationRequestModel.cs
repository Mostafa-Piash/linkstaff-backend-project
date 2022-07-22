using SocialNetwork.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Model.Auth
{
    public class RegistrationRequestModel: PersonModel
    {
        public string Password { get; set; }
    }
}
