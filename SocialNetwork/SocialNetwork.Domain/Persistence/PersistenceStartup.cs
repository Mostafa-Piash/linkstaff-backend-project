using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Domain.Persistence.Context;

namespace SocialNetwork.Domain.Persistence
{
    public static class PersistenceStartup
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialNetworkDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(""));
            });
        }
    }
}
