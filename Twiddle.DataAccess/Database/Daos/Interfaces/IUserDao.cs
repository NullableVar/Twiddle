using Twiddle.Models;

namespace Twiddle.DataAccess.Database.Daos.Interfaces;

public interface IUserDao
{
    Task CreateAsync(UserModel userModel);
    
    Task<UserModel?> GetByIdAsync(Guid id);
    
    Task<IList<UserModel>> GetAllAsync();
    
    Task UpdateAsync(UserModel model);
    
    Task<bool> DeleteAsync(Guid id);
}