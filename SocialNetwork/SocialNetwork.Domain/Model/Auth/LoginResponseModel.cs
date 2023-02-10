using SocialNetwork.Domain.Model.Person;

namespace SocialNetwork.Domain.Model.Auth
{
    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
        public PersonModel User { get; set; }
    }
}
