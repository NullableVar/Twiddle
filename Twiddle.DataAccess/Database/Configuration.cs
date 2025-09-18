using Microsoft.Extensions.DependencyInjection;

namespace Twiddle.DataAccess.Database;

public static class Configuration
{
    public static void ConfigureDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.ConfigureDao();
        serviceCollection.ConfigureMappers();
    }

    private static void ConfigureDao(this IServiceCollection serviceCollection)
    {
        
    }

    private static void ConfigureMappers(this IServiceCollection serviceCollection)
    {
        
    }
}