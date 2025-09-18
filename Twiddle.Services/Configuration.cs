using Microsoft.Extensions.DependencyInjection;
using Twiddle.Services.Interfaces;

namespace Twiddle.Services;

public static class Configuration
{
    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUserService, UserService>();
    }
}