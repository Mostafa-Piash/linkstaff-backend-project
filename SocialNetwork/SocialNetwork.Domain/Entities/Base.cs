namespace SocialNetwork.Domain.Entities
{
    public class Base<T>
    {
        public Base()
        {
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
            IsActive = true;
            IsDeleted = false;
        }
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
