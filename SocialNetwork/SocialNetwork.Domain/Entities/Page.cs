namespace SocialNetwork.Domain.Entities
{
    public class Page : Base<long>
    {
        public Page()
        {
            Posts = new HashSet<Post>();
            Followers = new HashSet<Follower>();
        }
        public string Name { get; set; }
        public long CreatorId { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Follower> Followers { get; set; }

    }
}
