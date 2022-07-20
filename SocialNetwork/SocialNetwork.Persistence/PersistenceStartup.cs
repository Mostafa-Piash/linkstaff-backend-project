using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
        }
    }
}
