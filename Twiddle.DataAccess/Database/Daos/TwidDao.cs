using Twiddle.DataAccess.Core;
using Twiddle.DataAccess.Database.Daos.Interfaces;
using Twiddle.DataAccess.Database.Entities;
using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Daos;

internal class TwidDao(IMapper<Twid, TwidModel> _twidModelMapper, IMapper<TwidModel, Twid> _twidMapper) : ITwidDao
{
    public async Task CreateAsync(TwidModel twidModel)
    {
        await using var context = new TwiddleDb();

        context.Add(_twidMapper.Map(twidModel));
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TwidModel twidModel)
    {
        await using var context = new TwiddleDb();
        
        var twidToUpdate = _twidMapper.Map(twidModel);
        context.Update(twidToUpdate);
        await context.SaveChangesAsync();
    }

    public async Task<TwidModel?> GetByIdAsync(Guid id)
    {
        await using var context = new TwiddleDb();
        
        var twidToReturn = context.Twids.FirstOrDefault(t => t.Id == id);
        return twidToReturn == null ? null : _twidModelMapper.Map(twidToReturn);
    }

    public async Task<IList<TwidModel>> GetByUserIdAsync(Guid id)
    {
        await using var context = new TwiddleDb();
        
        var twidsToReturn = context.Twids.Where(t => t.UserId == id).ToList();
        return twidsToReturn.Select(_twidModelMapper.Map).ToList();
    }

    public async Task<IList<TwidModel>> GetAllAsync()
    {
        await using var context = new TwiddleDb();
        
        var twidsToReturn = context.Twids.ToList();
        return twidsToReturn.Select(_twidModelMapper.Map).ToList();
    }
}