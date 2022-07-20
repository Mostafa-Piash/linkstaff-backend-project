using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Interfaces.Repositories;

namespace SocialNetwork.Repositories
{
    public static class RepositoriesStartup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
        }
    }
}