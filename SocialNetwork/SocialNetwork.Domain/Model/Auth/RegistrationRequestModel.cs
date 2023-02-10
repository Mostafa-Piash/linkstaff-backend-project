using SocialNetwork.Domain.Model.Person;

namespace SocialNetwork.Domain.Model.Auth
{
    public class RegistrationRequestModel : PersonModel
    {
        public string Password { get; set; }
    }
}
