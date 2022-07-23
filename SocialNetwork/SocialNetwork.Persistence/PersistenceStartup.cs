using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Persistence.Context;
using SocialNetwork.Persistence.Repositories;

namespace SocialNetwork.Persistence
{
    public static class PersistenceStartup
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialNetworkDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"), migration=> migration.MigrationsAssembly("SocialNetwork.Persistence"));
            });
           
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Person>, Repository<Person>>();
            services.AddScoped<IRepository<Page>, Repository<Page>>();
            services.AddScoped<IRepository<Post>, Repository<Post>>();
            services.AddScoped<IRepository<Follower>, Repository<Follower>>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

        }
    }
}
