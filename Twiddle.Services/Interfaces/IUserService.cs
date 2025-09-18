using Twiddle.Models;

namespace Twiddle.Services.Interfaces;

public interface IUserService
{
    public Task<bool> RegisterAsync(UserModel userModel);

    public Task<UserModel?> GetByIdAsync(Guid id);
    
    public Task<bool> LoginAsync(UserModel userModel);
}