using Twiddle.Models;
using Twiddle.Services.Interfaces;
using Twiddle.DataAccess.Database.Daos.Interfaces;

namespace Twiddle.Services;

internal class TwidService(ITwidDao _twidDao) : ITwidService
{
    public async Task CreateAsync(TwidModel twidModel)
    {
        await _twidDao.CreateAsync(twidModel);
    }

    public async Task UpdateAsync(TwidModel twidModel)
    {
        await _twidDao.UpdateAsync(twidModel);
    }

    public async Task<TwidModel?> GetByIdAsync(Guid id)
    {
        return await _twidDao.GetByIdAsync(id);
    }

    public async Task<IList<TwidModel>> GetByUserIdAsync(Guid userId)
    {
        return await _twidDao.GetByUserIdAsync(userId);
    }

    public async Task<IList<TwidModel>> GetAllAsync()
    {
        return await _twidDao.GetAllAsync();
    }
}