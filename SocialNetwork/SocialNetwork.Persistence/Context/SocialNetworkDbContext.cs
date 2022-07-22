using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Persistence.Context
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                        .HasMany(m => m.Posts)
                        .WithOne(o => o.Person)
                        .HasForeignKey(x => x.CreatedByPerson);

            modelBuilder.Entity<Page>()
                        .HasMany(m => m.Posts)
                        .WithOne(o => o.Page)
                        .HasForeignKey(x => x.CreatedByPage);

            modelBuilder.Entity<Person>()
                        .HasMany(m => m.Followers)
                        .WithOne(o => o.Person)
                        .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Page>()
                        .HasMany(m => m.Followers)
                        .WithOne(o => o.Page)
                        .HasForeignKey(x => x.PageId);

            modelBuilder.Entity<Person>()
                       .HasMany(m => m.Pages)
                       .WithOne(o => o.Person)
                       .HasForeignKey(x => x.CreatorId);


        }
    }
}
