namespace SocialNetwork.Domain.DTOs
{
    public class PostDto
    {
        public long PostId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByPerson { get; set; }
        public string CreatedByPage { get; set; }

    }
}
