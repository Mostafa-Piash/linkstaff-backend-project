namespace SocialNetwork.Domain.Entities
{
    public class Person: Base<long>
    {
        public Person()
        {
            Posts = new HashSet<Post>();
            Followers = new HashSet<Follower>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }
    }
}
