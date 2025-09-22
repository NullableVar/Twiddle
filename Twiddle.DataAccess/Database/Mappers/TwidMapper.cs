using Twiddle.DataAccess.Core;
using Twiddle.DataAccess.Database.Entities;
using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Mappers;

internal class TwidMapper : IMapper<TwidModel, Twid>
{
    public Twid Map(TwidModel source)
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