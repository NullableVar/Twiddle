using Microsoft.Extensions.DependencyInjection;
using Twiddle.DataAccess.Core;
using Twiddle.DataAccess.Database.Daos;
using Twiddle.DataAccess.Database.Daos.Interfaces;
using Twiddle.DataAccess.Database.Entities;
using Twiddle.DataAccess.Database.Mappers;
using Twiddle.Models;

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
        serviceCollection.AddSingleton<IUserDao, UserDao>();
        serviceCollection.AddSingleton<ITwidDao, TwidDao>();
    }

    private static void ConfigureMappers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMapper<UserModel, User>, UserMapper>();
        serviceCollection.AddSingleton<IMapper<User, UserModel>, UserModelMapper>();
        serviceCollection.AddSingleton<IMapper<TwidModel, Twid>, TwidMapper>();
        serviceCollection.AddSingleton<IMapper<Twid, TwidModel>, TwidModelMapper>();
    }
}