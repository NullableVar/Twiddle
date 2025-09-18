using System.Security.Cryptography;
using System.Text;
using Twiddle.DataAccess.Database.Daos.Interfaces;
using Twiddle.Models;
using Twiddle.Services.Interfaces;

namespace Twiddle.Services;

internal class UserService(IUserDao _userDao) : IUserService
{
    public async Task<bool> RegisterAsync(UserModel userModel)
    {
        userModel.Password = EncryptPassword(userModel.Password!);
        await _userDao.CreateAsync(userModel);
        return await Task.FromResult(true);
    }

    public async Task<bool> LoginAsync(UserModel userModel)
    {
        var userToLogin = await _userDao.GetByEmailAsync(userModel.Email!);
        
        if (userToLogin == null) 
            return await Task.FromResult(false);
        
        return await Task.FromResult(userToLogin.Password == EncryptPassword(userModel.Password!));
    }
    
    private string EncryptPassword(string password)
    {
        using var sha256 = SHA256.Create();
        UTF8Encoding objUtf8 = new UTF8Encoding();
        var bytePassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytePassword);
    }
}