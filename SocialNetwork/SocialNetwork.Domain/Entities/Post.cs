namespace SocialNetwork.Domain.Entities
{
    public class Post : Base<long>
    {
        public string Status { get; set; }
        public long CreatedByPerson { get; set; }
        public long CreatedByPage { get; set; }

        public virtual Person Person { get; set; }
        public virtual Page Page { get; set; }

    }
}
