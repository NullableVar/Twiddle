using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Daos.Interfaces;

public interface ITwidDao
{
    public Task CreateAsync(TwidModel twidModel);
    
    public Task UpdateAsync(TwidModel twidModel);
    
    public Task<TwidModel?> GetByIdAsync(Guid id);

    public Task<IList<TwidModel>> GetByUserIdAsync(Guid id);
    
    public Task<IList<TwidModel>> GetAllAsync();
}