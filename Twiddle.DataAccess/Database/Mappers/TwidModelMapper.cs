using Twiddle.DataAccess.Core;
using Twiddle.DataAccess.Database.Entities;
using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Mappers;

internal class TwidModelMapper : IMapper<Twid, TwidModel>
{
    public TwidModel Map(Twid source)
    {
        return new()
        {
            Id = source.Id,
            UserId = source.UserId,
            Text = source.Text,
            CreatedAt = source.CreatedAt,
        };
    }
}