using Twiddle.DataAccess.Core;
using Twiddle.DataAccess.Database.Entities;
using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Mappers;

internal class UserModelMapper : IMapper<User, UserModel>
{
    public UserModel Map(User source)
    {
        return new()
        {
            Id = source.Id,
            Email = source.Email,
            Name = source.Username,
            Password = source.PasswordHash,
            CreatedAt = source.CreatedAt
        };
    }
}