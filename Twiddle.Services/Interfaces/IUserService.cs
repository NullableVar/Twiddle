using Twiddle.Models;

namespace Twiddle.Services.Interfaces;

public interface IUserService
{
    public Task<bool> RegisterAsync(UserModel userModel);
    
    public Task<bool> LoginAsync(UserModel userModel);
}