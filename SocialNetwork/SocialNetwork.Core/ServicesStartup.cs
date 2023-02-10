using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Services;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.Core
{
    public static class ServicesStartup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<IPersonService, PersonService>();
        }

    }
}