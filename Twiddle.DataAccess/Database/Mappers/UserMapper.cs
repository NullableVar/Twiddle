using Twiddle.DataAccess.Core;
using Twiddle.DataAccess.Database.Entities;
using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Mappers;

internal class UserMapper : IMapper<UserModel, User>
{
    public User Map(UserModel source)
    {
        return new()
        {
            Id = source.Id,
            Email = source.Email,
            Username = source.Name,
            PasswordHash = source.Password,
            CreatedAt = source.CreatedAt
        };
    }
}