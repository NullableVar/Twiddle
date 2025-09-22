using Twiddle.Models;

namespace Twiddle.Services.Interfaces;

public interface ITwidService
{
    Task CreateAsync(TwidModel twidModel);
    
    Task UpdateAsync(TwidModel twidModel);
    
    Task<TwidModel?> GetByIdAsync(Guid id);
    
    Task<IList<TwidModel>> GetByUserIdAsync(Guid userId);
    
    Task<IList<TwidModel>> GetAllAsync();
}