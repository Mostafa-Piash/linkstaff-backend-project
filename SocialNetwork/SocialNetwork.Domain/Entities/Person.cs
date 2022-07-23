using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entities
{
    public class Person: Base<long>
    {
        public Person()
        {
            Posts = new HashSet<Post>();
            Followers = new HashSet<Follower>();
            Pages= new HashSet<Page>();
        }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
